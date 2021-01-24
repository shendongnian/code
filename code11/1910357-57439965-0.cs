    using System;
    using HtmlAgilityPack;
    
    public class Program
    {
    	
        public static void Main()
        {
            string url = "http://www.ndrf.gov.in/tender";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            var nodetest1 = htmlDoc.DocumentNode.SelectSingleNode("//table");  
            Console.WriteLine(nodetest1.InnerText); 
        }
    }
