    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string URL = "https://www.sciencedaily.com/rss/top/technology.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
            }
        }
    }
