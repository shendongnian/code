    class Program
    {
        static void Main(string[] args)
        {
            Parse();
        }
        public static void Parse()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\New Text Document.xsd");
            var xdocument = xmlDoc.ToXDocument();
            foreach (var element in xdocument.Elements())
            {
                foreach (var node in element.Elements()) //childs...
                {
               
                    if (node.Name.LocalName.Equals("ElementType"))
                    {
                        foreach (var scopeNode in node.Elements())  
                        {
                            if (scopeNode.HasAttributes)
                            {
                                var xml = XElement.Parse(scopeNode.ToString());
                                var name = xml.Attribute("name")?.Value;
                                var label = xml.Attribute("label")?.Value;
                                var uid= xml.Attribute("UID")?.Value;
                            }
                            var value = scopeNode.Value;   //capture value e.g <description>abcd</description>
                        }
                    }
                }
            }
        }
    }
    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
