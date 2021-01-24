    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication137
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string[] description = doc.Descendants().Where(x => x.Name.LocalName == "ArticleDescription").Select(x => (string)x).ToArray();
            }
        } 
    }
