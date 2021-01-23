    public static XmlNode ConvertToXmlDocument(IHTMLDocument2 doc2)
    {
        XmlDocument xmlDoc = new XmlDocument();
        IHTMLDOMNode htmlNodeHTML = null;
        XmlNode xmlNodeHTML = null;
        try
        {
            htmlNodeHTML = (IHTMLDOMNode)((IHTMLDocument3)doc2).documentElement;
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", ""/*((IHTMLDocument2)htmlDoc.DomDocument).charset*/, ""));
            xmlNodeHTML = xmlDoc.CreateElement("html"); // create root node
            xmlDoc.AppendChild(xmlNodeHTML);
            CopyNodes(xmlDoc, xmlNodeHTML, htmlNodeHTML);
        }
        catch (Exception err)
        {
            Utils.WriteLog(err, "Html2Xml.ConvertToXmlDocument");
        }
