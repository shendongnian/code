    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = @"Enter URL Here";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                List<XElement> items = doc.Descendants("item").ToList();
            }
        }
    }
