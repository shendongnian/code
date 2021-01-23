    namespace ExplicitXmlClosingTags
    {
        using System.Xml;
        using System.Xml.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                const string ElementRoot = "RootElement";
                const string ElementChild = "ChildElement";
                const string AttributeChild = "ChildAttribute";
                XDocument xDoc = new XDocument();
                XElement root = new XElement(ElementRoot);
                XElement child = new XElement(ElementChild, string.Empty);
                root.Add(child);
                child.SetAttributeValue(AttributeChild, "AttrValue");
                xDoc.Add(root);
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Indent = true;
                using (XmlWriter xw = XmlWriter.Create("out.xml", xws))
                {
                    xDoc.Save(xw);    
                }
            }
        }
    }
