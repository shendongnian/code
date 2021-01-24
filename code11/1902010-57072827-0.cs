    public class GTSLocation 
    {
        public string WorkingSiteId {get;set;} //GUID
        public double Longitude {get;set;}
        public double Latitude {get;set;}
        public DateTime Timestamp {get;set;}
        //New property -> We will use it in the binding!
        public GTSWorkingSite WorkingSite {get;set;}
    }
    public class GTSWorkingSite
    {
        public string Id {get;set;} //GUID
        public string Name {get;set;}
        public string Description {get;set;}
    }
