    public class Test
    {
        public void Run()
        {
            //Load the xml and serialize it into instances of our classes
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(AirAvailabilityResults));
    
            System.IO.StringReader sr = new System.IO.StringReader(sXmlResult);
            AirAvailabilityResults results = (AirAvailabilityResults)ser.Deserialize(sr);
    
            //Now we can access all the data like we would any other object.
            foreach (AirAvailabilityReply reply in results.AirAvailabilityReply)
            {
                double dNativeBaseFare = reply.RateInfo.nativeBaseFare;
                foreach (FlightSegment segment in reply.FlightSegment)
                {
                    int iFlightNumber = segment.flightNumber;
                }
            }
        }
    }
    
    //Create the seriealizable classes to represent the xml.  
    //I created these by infering the schema from the xml.  These classes may need some changes, if 
    //they don't exactly match the actual schema that expedia uses
    public class AirAvailabilityResults
    {
        [System.Xml.Serialization.XmlElement()]
        public AirAvailabilityReply[] AirAvailabilityReply { get; set; }
            
        [System.Xml.Serialization.XmlAttribute()]
        public int size {get;set;}
            
        [System.Xml.Serialization.XmlElement()]
        public string cacheKey {get;set;}
            
        [System.Xml.Serialization.XmlElement()]
        public string cacheLocation {get;set;}
    
    }
    
    public class AirAvailabilityReply
    {
        public enum SupplierType
        {
            S
        }
        public enum TripType
        {
            R
        }
        public enum TicketType
        {
            E
        }
    
        [System.Xml.Serialization.XmlElement()]
        public SupplierType supplierType {get;set;}
    
        [System.Xml.Serialization.XmlElement()]
        public TripType tripType {get;set;}
    
        [System.Xml.Serialization.XmlElement()]
        public TicketType ticketType {get;set;}
    
        public RateInfo RateInfo { get; set; }
    
        [System.Xml.Serialization.XmlElement()]
        public FlightSegment[] FlightSegment {get;set;}
    }
    
    public class RateInfo
    {
        public double nativeBaseFare {get;set;}
        public double nativeTotalPrice {get;set;}
        public string nativeCurrencyCode { get; set; }
        public double displayBaseFare {get;set;}
        public double displayTotalPrice {get;set;}
        public string displayCurrencyCode { get; set; }
    }
    
    public class FlightSegment
    {
        public bool segmentOutgoing {get;set;}
        public string airlineCode {get;set;}
        public string airline {get;set;}
        public int flightNumber {get;set;}
        public string originCityCode {get;set;}
        public string destinationCityCode {get;set;}
        public string departureDateTime {get;set;}
        public string arrivalDateTime { get; set; }
        public string fareClass {get;set;}
        public string equipmentCode {get;set;}
        public int numberOfStops {get;set;}
        public string originCity {get;set;}
        public string originStateProvince {get;set;}
        public string originCountry {get;set;}
        public string destinationCity {get;set;}
        public string desintationStateProvince {get;set;}
        public string destinationCountry { get; set; }
    }
