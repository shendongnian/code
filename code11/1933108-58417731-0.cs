    [Serializable, XmlRoot("Sites")]
    public class Sites
    {
        [XmlElement("PostCodeValidatedSite")]
        public List<PostCodeValidatedSite> PostCodeValidatedSites { get; set; }
    }
    public class PostCodeValidatedSite
    {
        public Address Address { get; set; }
    }
