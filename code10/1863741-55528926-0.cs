    public static string XmlDecode(string value) {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml("<root>" + value + "</root>");
        return xmlDoc.InnerText;
    }
