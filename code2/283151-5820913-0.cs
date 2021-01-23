    [XmlRoot(ElementName = "return_obj")]
    public class returnobject
    {
        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public category[] categories { get; set; }
    }
