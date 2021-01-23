    public Guid Guid
    {
        get { return m_guid; }
        set { if (value != null) Debugger.Log(0, "Warning", "This property has an empty setter, just for serializing purpose!"); }
    }
