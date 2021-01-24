    [XmlRoot(ElementName = "instance")]
    public class Instance
    {
        [XmlElement(ElementName = "general")]
        public InstanceGeneral General { get; set; }  //<= InstanceGeneral  Use Here
    }
    
    [XmlRoot(ElementName = "overview")]
    public class Overview
    {
        [XmlElement(ElementName = "general")]
        public OverviewGeneral General { get; set; }  //<= OverviewGeneral Use Here
        [XmlElement(ElementName = "instance")]
        public Instance Instance { get; set; }
    }
    
