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
                XNamespace xsiNs = doc.Root.GetNamespaceOfPrefix("xsi");
                List<XElement> removeNodes = doc.Descendants("ItemModel").Where(x => (string)x.Attribute(xsiNs + "type") == "TypeDelete").ToList();
                for (int i = removeNodes.Count - 1; i >= 0; i--)
                {
                    removeNodes[i].Remove();
                }
            }
        }
     
    }
