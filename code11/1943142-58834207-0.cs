    string result;
    using (var writer = new StringWriter())
    {
        new XmlSerializer(typeof(Characteristic)).Serialize(writer, lstChars);
        result = writer.ToString();
    }
