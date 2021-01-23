    using System.Xml.XPath;
    var document = XDocument.Load(fileName);
    var namespaceManager = new XmlNamespaceManager(new NameTable());
    namespaceManager.AddNamespace("empty", "http://demo.com/2011/demo-schema");
    var name = document.XPathSelectElement("/empty:Report/empty:ReportInfo/empty:Name", namespaceManager).Value;
