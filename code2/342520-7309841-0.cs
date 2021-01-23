    [XmlRoot("root")]
    public class ListOfRates 
    {
        [XmlArray("ArrayOfRates")]
        [XmlArrayItem("Rate")]
        public List<CbrRate> Rates { get; set; }
    }
