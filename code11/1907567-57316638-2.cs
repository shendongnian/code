    private readonly Weather weather;
    public string AirportName { get; set; }
    public List<Plane> planes;    
    public Airport(string airportName, Weather weather)
    {
        planes = new List<Plane>();
        AirportName = airportName;
        weather = weather; 
    }
