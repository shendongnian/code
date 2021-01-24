    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Key> keys = doc.Descendants("Key").Select(x => new Key()
                {
                    Name = (string)x.Element("Name"),
                    Values = x.Descendants("KeyValue").Select(y => new KeyValue() {
                        Value = (string)y,
                        Offered = (bool)y.Attribute("Offered"),
                        Order  = (int?)y.Attribute("Order")
                    }).ToList()
                }).ToList();
            }
     
        }
        public class Key
        {
            public string Name { get; set; }
            public List<KeyValue> Values { get;set;}
        }
        public class KeyValue
        {
            public string Value { get; set; }
            public int? Order { get; set; }
            public bool Offered { get; set; }
        }
     
     
    }
