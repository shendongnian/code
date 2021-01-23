    [XmlRoot("config")]
    public class SourceConfig
    {
        public string Description { get; set; }
    
        public string HelpLink { get; set; }
    
        [XmlElement("param")]
        public List<Params> param { get; set; }
    }
    
