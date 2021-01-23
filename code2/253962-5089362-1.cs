    public class TopTen
    {
    
        public string SectorName { get; set; }
        public DateTime PerformanceTo { get; set; }
        [XmlElement("OrderedShareClassReturns")]
        public List<ReturnsWrapper> Returns { get; set; }
    }
