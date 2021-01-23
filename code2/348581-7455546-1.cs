    [XmlIgnore]
    public bool SomeValue { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlElement("SomeValue")]
    public int SomeValueForSerialization
    {
        get
        {
            return SomeValue ? 1 : 0;
        }
        set
        {
            SomeValue = value != 0;
        }
    }
