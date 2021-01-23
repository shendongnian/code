    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string EmploeeName {
        get { return Emploee.Name; }
        set { Emploee.Name = value; }
    }
    public bool ShouldSerializeEmploeeName() { return false;}
