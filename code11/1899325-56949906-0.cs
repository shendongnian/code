    public class Garage
    {
        public string owner { get; set; }
        [XmlAnyElement]
        public XElement[] cars { get; set; }
    }
