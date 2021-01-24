    public byte[] CreateHtml(string xmlRoute, string xlsRoute)
    {
        var xslt = new XslCompiledTransform();
        xslt.Load(xlsRoute);
        using (var stream = new MemoryStream())
        using (var writer = XmlWriter.Create(stream))
        {
            xslt.Transform(xmlRoute, writer);
            return stream.ToArray();
        }
    }
