    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><r><a><k>key1</k><v><![CDATA[<?xml version=\"1.0\" encoding=\"utf-8\"?><foo><bar>Hahaha</bar></foo>]]></v></a><a><k>key2</k><v>value2</v></a></r>";
    
                 PrintDictionary(XmlToDictionaryLINQ(xml));
                 PrintDictionary(XMLToDictionaryNoLINQ(xml));
            }
    
            private static Dictionary<string, string> XMLToDictionaryNoLINQ(string xml)
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
    
                var nodes = doc.SelectNodes("//a");
    
                var result = new Dictionary<string, string>();
                foreach (XmlNode node in nodes)
                {
                    result.Add(node["k"].InnerText, node["v"].InnerText);
                }
    
                return result;
            }
    
            private static Dictionary<string, string> XmlToDictionaryLINQ(string xml)
            {
                var doc = XDocument.Parse(xml);
                var result =
                    (from node in doc.Descendants("a")
                     select new { key = node.Element("k").Value, value = node.Element("v").Value })
                    .ToDictionary(e => e.key, e => e.value);
                return result;
            }
    
            private static void PrintDictionary(Dictionary<string, string> result)
            {
                foreach (var i in result)
                {
                    Console.WriteLine("key: {0}, value: {1}", i.Key, i.Value);
                }
            }
        }
    }
