    private static void GetCountries()
        {
            if(countries.Count == 0)
            {
                  string query = $"SELECT Id, Name FROM Countries";
                  countries = Common.GetCollection<Country>(Properties.Settings.Default.DbConnectionString, query)
                  .ToDictionary(x => x.Id, x=> x.Name);
            }
        }
