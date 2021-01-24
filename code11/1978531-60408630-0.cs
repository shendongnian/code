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
                XNamespace mNs = doc.Root.GetNamespaceOfPrefix("m");
                XNamespace dNs = doc.Root.GetNamespaceOfPrefix("d");
                Dictionary<string, string> dict = doc.Descendants(mNs + "properties").Elements()
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
