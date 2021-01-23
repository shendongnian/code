    XmlSerializer serializer = new XmlSerializer(someobj.GetType());
    string asString = null;
    using (StringWriter writer = new StringWriter())
    {
        serializer.Serialize(writer, someobj);
        asString = writer.ToString();
    }
    string weirdXml = asString.Replace("<Value>True</Value>","<Value>").Replace("<Value>False</Value>","<Value/>");
