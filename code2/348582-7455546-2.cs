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
            // Or do strict validation, and throw whatever exception you'd like.
            // Preferably one the serializer will already throw, tho :)
        }
    }
