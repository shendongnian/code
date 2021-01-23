    DataContractSerializer ser =
        new DataContractSerializer(typeof(Config));
    using (Stream s = new MemoryStream())
    {
        ser.WriteObject(s, new Config());
        s.Position = 0;
        using(var writer = XmlWriter.Create(Console.Out)) {
            ser.WriteObject(writer, ser.ReadObject(s));
        }
    }
