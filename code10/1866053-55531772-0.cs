    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication107
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("subscription_add_on").Select(x => new
                {
                    add_on_code = (string)x.Element("add_on_code"),
                    name = (string)x.Element("name"),
                    quantity = (int)x.Element("quantity"),
                    amount = (int)x.Element("unit_amount_in_cents"),
                    add_on_type = (string)x.Element("add_on_type")
                }).ToList();
     
            }
        }
     
     
    }
