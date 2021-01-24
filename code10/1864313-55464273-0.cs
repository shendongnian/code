    private static Dictionary<string, int> CountryIds;
    
    public static NameOfYourClass(){
        CountryIds = new Dictionary<string, int>();
        string query = $"SELECT Id, Name FROM Countries";
        List<Country> cases = Common.GetCollection<Country>(Properties.Settings.Default.DbConnectionString, query);
        foreach (country Country in cases)
        {
            CountryIDs.Add(Country.Name, Country.Id);
        }        
    }
    public static int GetCountryId(string countryName)
    {
        if(!CountryIds.Contains(countryName) return 0;
        return CountryIds[countryName];
    }
