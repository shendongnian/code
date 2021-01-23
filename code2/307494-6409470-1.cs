    // note: doesn't work; see answer text
    [XmlIgnore]
    public bool ConflictListSpecified
    {
        get { return ConflictList != null; }
        set { if (!value) ConflictList = null; }
    }
