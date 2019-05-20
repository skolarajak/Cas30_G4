using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;


namespace Cas_30
{
    class Testovi
    {
        //definisanje i inizijalizacija promenljivih
        IWebDriver driver;
        
        //setup
        [SetUp]
        //metoda koja inicijalizuje promenljivu driver na novu instancu firefox instance
        public void OpenBrowser()
        {
            driver = new FirefoxDriver();
        }

        public void GoToURL(string url)
        {
            this.driver.Url = url;
        }

        [Test]
        public void Cas30Test1()
        {
            GoToURL("https://www.seleniumeasy.com/test/table-sort-search-demo.html");
            Thread.Sleep(5000);

            //definisanje tabele
            IWebElement table = driver.FindElement(By.Id("example"));

            //provera da li je tabela prikazana
            bool chk = table.Displayed;
            //izvlacenje raznih property-ja tabele
            string att1 = table.GetAttribute("class");
            string att2 = table.GetCssValue("background-color");
            string att3 = table.GetProperty("id");
            string att4 = table.TagName;

            //upis u txt fajl
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", "--------------------------" + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", "Vrednost promenljive chk je " + chk + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", att1 + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", att2 + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", att3 + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", att4 + Environment.NewLine);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", "--------------------------" + Environment.NewLine);

            //klik na element za sortiranje
            IWebElement position = driver.FindElement(By.XPath("//th[@aria-label='Position: activate to sort column ascending']"));
            position.Click();

            //trazenje svih elemenata koji su sortirani (iz tabele)
            IList<IWebElement> tablesRowSorting = driver.FindElements(By.XPath("//td[@class='sorting_1']"));

            //za svaki element iz liste tablesRowSorting
            foreach (var item in tablesRowSorting)
            {
                //dodeli elemente promenljivoj el, tipa string
                string el = item.Text.ToString();
                System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", DateTime.Now + " " + el + Environment.NewLine);
            }
            Thread.Sleep(2000);

            //ispis odredjenog elementa u tabeli
            IWebElement tokyo = table.FindElement(By.XPath("//td[contains(.,'Tokyo')]"));
            bool isDisplayed = tokyo.Displayed;
            string isDispl = Convert.ToString(isDisplayed);
            System.IO.File.AppendAllText(@"C:\SeleniumTxt\Cas30.txt", DateTime.Now + "Element Tokyo je prikazan " + isDispl + Environment.NewLine);
        }



        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
