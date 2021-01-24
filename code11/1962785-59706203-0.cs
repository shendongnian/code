    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Net;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string filename = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(filename);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                List<Key> keys = doc.Descendants(ns + "key").Select(x => new Key()
                {
                    _for = (string)x.Attribute("for"),
                    attrName = (string)x.Attribute("attr.name"),
                    id = (string)x.Attribute("id"),
                    fileType = (string)x.Attribute("yfiles.type")
                }).ToList();
                Dictionary<string, Key> dict = keys.GroupBy(x => x.id, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class Key
        {
            public string _for { get; set; }
            public string attrName { get; set; }
            public string id { get; set; }
            public string fileType { get; set; }
        }
    }
