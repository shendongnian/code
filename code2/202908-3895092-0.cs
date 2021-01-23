    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HtmlAgilityPack;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "http://www.stackoverflow.com";
    
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc = hw.Load(s);
    
                HtmlNodeCollection items = doc.DocumentNode.SelectNodes("//a[@class='question-hyperlink']");
                foreach (HtmlNode item in items)
                {
                    Console.WriteLine(item.InnerHtml);
                }
    
                Console.ReadLine();
            }
        }
    }
