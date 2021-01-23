    public class ApiCaller 
    {
       
        public DellAsset GetDellAsset(string serviceTag, string apiKey)
        {
         ....
        }
    }
    public class DellAsset
    {
        public string CountryLookupCode { get; set; }
        public string CustomerNumber { get; set; }
        public bool IsDuplicate { get; set; }
        public string ItemClassCode { get; set; }
        public string LocalChannel { get; set; }
        public string MachineDescription { get; set; }
        public string OrderNumber { get; set; }
        public string ParentServiceTag { get; set; }
        public string ServiceTag { get; set; }
        public string ShipDate { get; set; }
    }
