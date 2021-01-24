CountryView.Filter += CountryFilter;
    public bool All { get; set; }
    public bool Africa { get; set; }
    public bool Asia { get; set; }
    public bool Europe { get; set; }
    public bool America { get; set; }
        
    private bool CountryFilter(object obj)
    {
        var country = obj as Country;
        if (country== null) return false;
        if (All) return true;
        if (Africa) return country.Continent == Continent.Africa;
        if (Asia) return country.Continent == Continent.Asia;
        if (Europe) return country.Continent == Continent.Europe;
        if (America) return country.Continent == Continent.America;
        return true;
    }
