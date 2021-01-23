    private string _unit = "m/s";
    
    [PropertyValueDisplayedAs(new string[] { "m/s", "km/h" })]
    [TypeConverter(typeof(MyStringConverter))]
    public string ConstraintString
    {
        get { return _unit; }
        set { _unit = value; }
    }
