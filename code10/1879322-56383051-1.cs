    [XmlElement(ElementName = "reference", Type = typeof(Reference), IsNullable = true)]
    public Reference reference {get; set; }
  
    [XmlElement(ElementName = "error", Type = typeof(Error), IsNullable = true)]
    public Error error {get; set; }
