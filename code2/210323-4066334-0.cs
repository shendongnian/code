    [XmlIgnore]
    public Uri MyURI { get; set; }
    
    [XmlElement("MyURI")]
    public string MyURIAsString
    {
        get { return MyURI != null ? MyURI.AbsoluteUri : null; }
        set { MyUri = value != null ? new Uri(value) : null; }
    }
