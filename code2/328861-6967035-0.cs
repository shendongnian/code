    public string SpeedRepresentation
    {
        get
        {
            return string.Join(",", 
                               _speedCollection.Select(s => s.Speed().ToString())
                                               .ToArray());
        }
    }
