    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    using System.Threading;
    namespace SeleniumHap {
        class Program {
            static void Main(string[] args)
            {
                HtmlDocument doc = new HtmlDocument();
                string url = "http://www.oddsmath.com/football/sweden/division-1-1195/2019-04-26/if-sylvia-vs-nykopings-bis-2858046/";
                //string url = "http://www.oddsmath.com/";
                FirefoxOptions options = new FirefoxOptions();
                //options.AddArguments("--headless");
                IWebDriver driver = new FirefoxDriver(options);
                driver.Navigate().GoToUrl(url);
                while (true) {
                    doc.LoadHtml(driver.PageSource);
                    HtmlNode n = doc.DocumentNode.SelectSingleNode("//table[@id='table-odds-cat-0']//*[self::th or self::td]");
                    if (n != null) {
                        n = n.SelectSingleNode(".//div[@class='live-odds-loading']");
                        if (n == null) {
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Exited loop. Meaning the page is done loading since we could get a td. A Crude method but it works");
                HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
                foreach(HtmlNode table in tables) {
                    Console.WriteLine(table.GetAttributeValue("id", "No id"));
                    HtmlNodeCollection tableContent = table.SelectNodes(".//*[self::th or self::td]");
                    foreach(HtmlNode n in tableContent) {
                        Console.WriteLine(n.InnerHtml);
                    }
                    break;
                }
                Console.ReadKey();
            }
        }
    }
