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
            var captureElements = new List<CustomElements>();
            var xdocument = xmlDoc.ToXDocument();
            foreach (var element in xdocument.Elements())
            {
                foreach (var node in element.Elements()) //childs...
                {
                    if (node.Name.LocalName.Equals("ElementType"))
                    {
                        foreach (var scopeNode in node.Elements())
                        {
                            if (scopeNode.Name.LocalName.Equals("element"))
                            {
                                var xml = XElement.Parse(scopeNode.ToString());
                                var customElement = new CustomElements();
                                customElement.Type = xml.Attribute("type")?.Value;
                                customElement.Label = xml.Attribute("label")?.Value;
                                customElement.CompTypes = xml.Attribute("CompTypes")?.Value;
                                customElement.Readonly = xml.Attribute("readonly")?.Value;
                                customElement.Hidden = xml.Attribute("hidden")?.Value;
                                customElement.Require = xml.Attribute("require")?.Value;
                                captureElements.Add(customElement);
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
    public class CustomElements
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string CompTypes { get; set; }
        public string Readonly { get; set; }
        public string Hidden { get; set; }
        public string Require { get; set; }
    }
