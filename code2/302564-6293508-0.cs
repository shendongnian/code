    [XmlAttribute("brandstof")]
    public string FuelTypeString
    {
        get { return fuel.ToString(); }
        set
        {
            fuel = (Fuel)System.Enum.Parse(typeof(Fuel), value);
        }
    }
    [XmlIgnore()]
    public Fuel FuelType
    {
        get { return fuel; }
        set { fuel = value; }
    }
