    [XmlRoot("Car")]
    public class Car
    {
        [XmlElement("StockNumber")]
        public string StockNumber { get; set; }
        [XmlElement("Make")]
        public string Make { get; set; }
        [XmlElement("Model")]
        public string Model { get; set; }
    }
    [XmlRoot("Cars")]
    public class Cars
    {
        [XmlElement("Car")]
        public List<Car> Car { get; set; }
    }
    [XmlRoot("CarCollection")]
    public class CarCollection
    {
        [XmlElement("Cars")]
        public Cars Cars { get; set; }
    }
