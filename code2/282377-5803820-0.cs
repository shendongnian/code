    [XmlIgnore]
    public bool Value { get; set; }
    [XmlText]
    public string ValueString
    {
        get
        {
            return Value ? "<Value>" : "<Value/>";
        }
        set
        {
        }
    }
