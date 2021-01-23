    using (var memoryStream = new MemoryStream())
    {
        using (var xmlWriter = XmlWriter.Create(memoryStream))
        {
            xmlWriter.WriteString(xmlData.ToString().Trim());
            return new System.Data.SqlTypes.SqlXml(memoryStream);
        }
    }
