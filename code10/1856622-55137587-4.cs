    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {
        public object Header { get; set; }
        public EnvelopeBody Body { get; set; }
    }
    
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {
        [XmlArrayAttribute(Namespace = "http://sender.push.ws.nicbase.com/")]
        [XmlArrayItemAttribute("pushDataArray", Namespace = "", IsNullable = false)]
        public pushDataArray[] PushDataArray { get; set; }
    }
    
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class pushDataArray
    {
        public ushort assetId { get; set; }
    
        public string assetName { get; set; }
    
        public object boxData { get; set; }
    
        public string externalCustomerIdentification { get; set; }
    }
