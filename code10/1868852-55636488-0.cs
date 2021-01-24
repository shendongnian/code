    private Dictionary<int, Location> LocationsDict = new Dictionary<int, Location>();
    
    public void Set(int key, Location value)
    {
        if (LocationsDict.ContainsKey(key))
        {
            LocationsDict[key] = value;
        }
        else
        {
            LocationsDict.Add(key, value);
        }
    }
    
    public Location Get(int key)
    {
        Location result = null;
    
        if (LocationsDict.ContainsKey(key))
        {
            result = LocationsDict[key];
        }
    
        return result;
    }
