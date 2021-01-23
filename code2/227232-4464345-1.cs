    public static string XmlEscape(string unescaped)
    {
        XmlDocument doc = new XmlDocument();
        var node = doc.CreateAttribute("foo");
        node.InnerText = unescaped;
        return node.InnerXml;
    }
