    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string response = @"<?xml version='1.0' encoding='utf-8'?>
    <upload><image><name></name><hash>Some text</hash></image></upload>";
            
            XDocument doc = XDocument.Parse(response);
            
            foreach (XElement hashElement in doc.Descendants("hash"))
            {
                string hashValue = (string) hashElement;
                Console.WriteLine(hashValue);
            }
        }
    }
