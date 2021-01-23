    using (var stringWriter = new StringWriter())
    using (var writer = new XmlTextWriter(stringWriter))
    {
        writer.WriteRaw("</closingTagName>");
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 10;
        writer.WriteStartElement("Element1");
        writer.WriteStartElement("Element2");
        writer.WriteString("test");
        writer.WriteEndElement();
                
        writer.WriteEndElement();
                
        writer.WriteWhitespace(Environment.NewLine);
        writer.WriteStartElement("Element3");
        writer.WriteEndElement();
        var result = stringWriter.ToString();
