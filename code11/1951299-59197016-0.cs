    byte[] fileContent;
    using (var ms = new MemoryStream())
    {
        using (XmlWriter writer = XmlWriter.Create(ms, settings))
        {
            writer.WriteStartElement("HEADER");
            //.......Some more Code..............
            writer.Flush();
        }
        fileContent = ms.GetBuffer();
    }
    return File(fileContent , System.Net.Mime.MediaTypeNames.Text.Xml, "bill" + dateString1 + ".xml");
