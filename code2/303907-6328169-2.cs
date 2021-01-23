    public class adminViewModel
    {
        public HouseData   HouseData { get; set; }
        public string Status { get; set; }
        public ReferenceData ReferenceData { get {return ReferenceData.Instance; } 
    }
