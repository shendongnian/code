    [XmlRoot("ArrayOfRates")]
    public class ListOfRates 
    {
        [XmlArrayItem("Rate")]
        public List<CbrRate> Rates { get; set; }
    }
