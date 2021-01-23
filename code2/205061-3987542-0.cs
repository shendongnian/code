    [DataContract(Namespace = "")]   
    public class ContentStructure   
    {   
        [DataMember(Order = 0)]   
        [XmlElement("content_item")]   
        public List<ContentItem> Content { get; set; }   
    } 
