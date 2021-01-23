    [XmlIgnore]
    public int? B {get;set;}
    public bool ShouldSerializeBSerialized() {
        return B.HasValue;
    }
    [XmlElement("b")]
    public string BSerialized {
        get { return B.ToString(); }
        set {
           int tmp;
           if(value != null && int.TryParse(value.Trim(), out tmp))
           {
               B = tmp;
           }
        }
    }
