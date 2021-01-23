    using (var context = new MyEntities())
    {
        using (var writer = new XmlTextWriter("model.edmx", Encoding.Default))
        {
            EdmxWriter.WriteEdmx(context, writer);
        }
    }
