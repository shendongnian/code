    private static List<Country> countries;
    private static List<Country> GetCountries()
    {
        if (countries == null || countries.Count == 0)
        {
            string query = $"SELECT Id, Name FROM Countries";
            countries = Common.GetCollection<Country>(Properties.Settings.Default.DbConnectionString, query);
        }
        return countries;
    }
