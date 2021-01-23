    [XmlIgnore()]
    public ReadOnlyCollection<Bar> BarList
    {
        get { return _barList.AsReadOnly(); }
    }
    
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    //[Obsolete("This is only for serialization process", true)]
    [XmlArray("BarList")]
    [XmlArrayItem("Bar")]
    public List<Bar> XmlBarList
    {
        get { return _barList; }
        set { _barList = value; }
    }
