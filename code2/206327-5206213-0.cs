    [Description  ("The sharepoint's document type.")]
    [XmlIgnore]
    public DocumentType Type { get; set; }
    [Browsable    (false)]
    [XmlAttribute ("type")]
    public string TypeXml
    {
        get { return Type.ToString ().ToUpperInvariant () ; }
        set { Type = (DocumentType) Enum.Parse (typeof (DocumentType), value, true) ; }
    }
