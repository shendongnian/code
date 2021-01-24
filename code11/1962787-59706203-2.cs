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
                XNamespace yns = doc.Root.GetNamespaceOfPrefix("y");
                List<Key> keys = doc.Descendants(ns + "key").Select(x => new Key()
                {
                    _for = (string)x.Attribute("for"),
                    attrName = (string)x.Attribute("attr.name"),
                    id = (string)x.Attribute("id"),
                    fileType = (string)x.Attribute("yfiles.type")
                }).ToList();
                Dictionary<string, Key> dict = keys.GroupBy(x => x.id, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, List<string>> dict2 = doc.Descendants(ns + "node")
                    .SelectMany(x => x.Elements(ns + "data").Select(y => new { id = (string)x.Attribute("id"), key = (string)y.Attribute("key")}))
                    .GroupBy(x => x.key, y => y.id)
                    .ToDictionary(x => x.Key, y => y.ToList());
                foreach (KeyValuePair<string, List<string>> node in dict2)
                {
                    Key key = dict[node.Key];
                    key.nodes = node.Value.ToArray();
                }
                
            }
        }
        public class Key
        {
            public string _for { get; set; }
            public string attrName { get; set; }
            public string id { get; set; }
            public string fileType { get; set; }
            public string[] nodes { get; set; }
        }
    }
