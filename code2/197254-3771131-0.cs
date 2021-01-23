    private void DeserializeObject(string filename)
    {
        Console.WriteLine("Reading with Stream");
        // Create an instance of the XmlSerializer.
        XmlSerializer serializer = new XmlSerializer(typeof(TradeFills));
                                                            **********
