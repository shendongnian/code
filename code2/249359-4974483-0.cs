    [XmlElement("GetRecord", typeof(GetRecordType))]
    [XmlElement("Identify", typeof(IdentifyType))]
    public object ItemSerializer
    {
        get { return this.Item; }
        set { this.Item = (T)value; }
    }
    
    [XmlIgnore]
    public T Item
    //...
