    public void WriteXML(XmlWriter writer)
    {
        var lizer = new XmlSerializer(typeof(Foo), new Type[] { typeof(Bar) });
        lizer.Serialize(writer,SomeObject);
    }
