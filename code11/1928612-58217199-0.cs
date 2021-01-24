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
                XDocument oldDoc = XDocument.Load(FILENAME);
                XElement oldNodes = oldDoc.Descendants("nodes").FirstOrDefault();
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><sensortree><nodes></nodes></sensortree>";
                XDocument newDoc = XDocument.Parse(header);
                XElement newNodes = newDoc.Descendants("nodes").FirstOrDefault();
                GetTreeRecursively(oldNodes, newNodes);
     
            }
            static void GetTreeRecursively(XElement oldElement, XElement newElement)
            {
                string[] findTags = { "group", "probenode", "device", "sensor" };
                List<XElement> oldChildren = oldElement.Elements().Where(x => findTags.Contains(x.Name.LocalName)).ToList();
                foreach (XElement oldChild in oldChildren)
                {
                    XElement newChild = new XElement(oldChild.Name.LocalName, new XAttribute("id", (string)oldChild.Attribute("id")));
                    newChild.Add(oldChild.Element("name"));
                    newChild.Add(oldChild.Element("id"));
                    newElement.Add(newChild);
                    GetTreeRecursively(oldChild, newChild);
                }
            }
        }
    }
