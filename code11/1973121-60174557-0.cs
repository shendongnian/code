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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var contracts = doc.Descendants("contract").Select(x => new Contract()
                {
                    CONTRACTID = (string)x.Element("CONTRACTID"),
                    NAME = (string)x.Element("NAME"),
                    WHENMODIFIED = (DateTime)x.Element("WHENMODIFIED")
                });
            }
        }
        public class Contract
        {
            public string CONTRACTID { get; set; }
            public string NAME { get; set; }
            public DateTime WHENMODIFIED { get; set; }
        }
    }
