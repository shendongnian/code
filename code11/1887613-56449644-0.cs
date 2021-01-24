    var xml = XElement.Parse(
        "<root><value /><valueWithWhitespace>   </valueWithWhitespace></root>",
        LoadOptions.PreserveWhitespace
        );
                
    var stringWriter = new StringWriter();
    using (var xmlWriter = new CustomXmlTextWriter(stringWriter))
    {
        xml.WriteTo(xmlWriter);
        xmlWriter.Flush();
        Console.WriteLine(stringWriter);
    }
