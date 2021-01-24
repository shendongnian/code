CountryView.Filter += CountryFilter;
    private bool _All;
    private bool _Africa;
    private bool _Asia;
    private bool _Europe;
    private bool _America;
    public bool All { get=>_All; set { _All=value; CountryView.Refresh(); } }
    public bool Africa { get=> _Africa; set { _Africa=value; CountryView.Refresh(); } }
    public bool Asia { get=> _Asia; set { _Asia=value; CountryView.Refresh(); } }
    public bool Europe { get=> _Europe; set { _Europe=value; CountryView.Refresh(); } }
    public bool America { get=> _America; set { _America=value; CountryView.Refresh() ;} }}
        
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
