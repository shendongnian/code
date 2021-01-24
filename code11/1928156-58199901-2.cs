    public struct Export
    {
        [XmlElement("Destination")]
        public List<Destination> Destinations { get; set; }
    }
    public struct Destination
    {
        [XmlText()]
        public string Value { get; set; }
    }
    foreach (Destination destination in config.Export.Destinations)
    {
        Console.WriteLine(destination.Value);
    }
