    PreserveWhitespace(doc.DocumentElement);
    doc.DocumentElement.WriteTo(writer);
...
    private static void PreserveWhitespace(XmlElement root)
    {
        var nsmgr = new XmlNamespaceManager(root.OwnerDocument.NameTable);
        foreach (var element in root.SelectNodes("//*[@xml:space='preserve']", nsmgr)
            .OfType<XmlElement>())
        {
            if (element.HasChildNodes && !(element.FirstChild is XmlSignificantWhitespace))
            {
                var whitespace = element.OwnerDocument.CreateSignificantWhitespace("");
                element.InsertBefore(whitespace, element.FirstChild);
            }
        }
    }
