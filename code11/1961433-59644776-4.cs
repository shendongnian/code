    public class DomesticFlightInfo
    {
        public string FlightID { get; set; }
        public string FareID { get; set; }
        public bool IsInbound { get; set; }
    }
    
    public class RootObject
    {
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public List<DomesticFlightInfo> DomesticFlightInfos { get; set; }
    }
