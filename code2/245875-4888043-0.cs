    public void WriteXml(XmlWriter writer)
    {
        writer.WriteRaw(string.Format("<Status>{0}</Status>", Status));
        var xml = GenericType.Serialize();
        writer.WriteRaw(xml);
    }
