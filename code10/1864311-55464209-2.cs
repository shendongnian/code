    private static void GetCountries()
        {
            if(countries.Count == 0)
            {
                  string query = $"SELECT Id, Name FROM Countries";
                  countries = Common.GetCollection<Country>(Properties.Settings.Default.DbConnectionString, query)
                  .ToDictionary(x => x.Id, x=> x.Name);
            }
        }
    public static int GetCountryId(string countryName)
    {
        return countries.Contains(countryName) CountryIds[countryName] : 0;
    }
