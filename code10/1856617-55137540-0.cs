    [XmlRoot(ElementName = "pushDataArray")]
    public class pushDataArray
    {
        [XmlElement(ElementName = "assetId")]
        public string AssetId { get; set; }
        [XmlElement(ElementName = "assetName")]
        public string AssetName { get; set; }
        [XmlElement(ElementName = "boxData")]
        public BoxData BoxData { get; set; }
        [XmlElement(ElementName = "externalCustomerIdentification")]
        public string ExternalCustomerIdentification { get; set; }
    }
    [XmlRoot(ElementName = "Body",
             Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlArray(ElementName = "PushDataArray",
                  Namespace = "http://sender.push.ws.nicbase.com/")]
        [XmlArrayItem("pushDataArray")]
        public List<pushDataArray> PushDataArray { get; set; }
    }
