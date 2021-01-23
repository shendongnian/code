    [XmlIgnore]
    public Unit Height;
    
    [XmlElement("Unit")]
    public string HeightString
    {
        get {return Height.ToString();}
        set {Height = Unit.Parse(value);}
    }
