    using (var ms = new MemoryStream())
    {
        using (var writer = XmlWriter.Create(ms))
        {
            // write your XML here...
        }
        Response.ContentLength = ms.Length;
        Response.OutputStream.Write(ms.ToArray(), 0, ms.Length);
    }
