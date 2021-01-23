    private string Serialize(Object o)
    {
        using (var writer = new StringWriter())
        {
            new XmlSerializer(o.GetType()).Serialize(writer, o);
            return writer.ToString();
        }
    }
