    [XmlRoot("group", Namespace = "http://search.yahoo.com/mrss/")]
    public class MediaGroup
    {   
        [XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
        public MediaContent[] Items { get; set;}
    }
