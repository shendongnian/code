    using System;
    using System.IO;
    using System.Xml;
    
    public class Sample
    {
    
        public static void Main()
        {
    
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<input value='novel' ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "</input>");
    
            XmlNode root = doc.DocumentElement;
    
            XmlNode value = doc.SelectNodes("/*/@value")[0];
    
            Console.WriteLine("Inner text: " + value.InnerText);
            Console.WriteLine("InnerXml: " + value.InnerXml);
            Console.WriteLine("OuterXml: " + value.OuterXml);
            Console.WriteLine("Value: " + value.Value);
    
        }
    }
