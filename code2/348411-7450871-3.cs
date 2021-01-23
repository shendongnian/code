    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
    nsmgr.AddNamespace("content", "sitename.xsd");
    var topicNodes = xdoc.SelectNodes("//content:Topic", nsmgr);
    foreach (XmlNode node in topicNodes)
    {
        string topic = node.Attributes["TopicName"].Value;
    }
