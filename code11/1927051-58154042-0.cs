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
                    if (node.Name.LocalName.Equals("objectId"))
                    {
                        // obj.Id = node.Value;
                    }
                    if (node.Name.LocalName.Equals("name"))
                    {
                        //obj.Name = node.Value;
                    }
                    if (node.Name.LocalName.Equals("scope"))
                    {
                        foreach (var scopeNode in node.Elements())  //more childs
                        {
                            if (scopeNode.Name.LocalName.Equals("id"))
                            {
                                //  obj.ScopeId = scopeNode.Value;
                            }
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
