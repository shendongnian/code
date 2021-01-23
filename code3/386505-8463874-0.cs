    [XmlIgnore]
    public decimal Price {get;set;}
    [XmlElement("price")]
    public string PriceFormatted {
        get { return Price.ToString(...); }
        set { Price = decimal.Parse(...); } 
    }
