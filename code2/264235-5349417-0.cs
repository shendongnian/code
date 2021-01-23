    public static XElement HtmlToXElement(string html)
    {
        if (html == null)
            throw new ArgumentNullException("html");
        HtmlDocument doc = new HtmlDocument();
        doc.OptionOutputAsXml = true;
        doc.LoadHtml(html);
        using (StringWriter writer = new StringWriter())
        {
            doc.Save(writer);
            using (StringReader reader = new StringReader(writer.ToString()))
            {
                return XElement.Load(reader);
            }
        }
    }
