    private Dictionary<string, Country> _countryNames = null;
    public Dictionary<string, Country> CountryNames
    {
        get
        {
             if(_countryNames == null)
             {
                 _countryNames = new Dictionary<int, Country>();
                 foreach(var country in GetCountries())
                 {
                     _countryNames.Add(country.Name, country)
                 }
             }
             return _countryNames;
        }
    }
    public static int GetCountryId(string countryName)
    {
        Country result;
        CountryNames.TryGetValue(countryName, out result);
        if (result == null) return 0;
        return result.Id;
    }
    private static IEnumerable<Country> GetCountries()
    {
        string query = "SELECT Id, Name FROM Countries";
        return Common.GetCollection<Country>(Properties.Settings.Default.DbConnectionString, query);
    }
