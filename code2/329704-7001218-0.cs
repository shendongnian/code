    public double[] Location { get; set; }
    public double Latitude
    {
        get { return _latitude; }
        set
        {
            Location[1] = value;
            _latitude = value;
        }
    }
    public double Longitude
    {
        get { return _longitude; }
        set
        {
            Location[0] = value;
            _longitude = value;
        }
    }
    public MyClass()
    {
        Location = new double[2];
    }
