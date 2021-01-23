    public static string[] GetPeopleAutoComplete(string filter, int maxResults, string searchType, string searchOption)
        {
            var property = typeof(PeopleCollection.people).GetProperty(searchType);
            var method = typeof(string).GetMethod(searchOption, new[] { typeof(string) });
                
            var query = from people in _context.People select people;
            
            return query.Distinct(new ForCompare(searchType))
                .Select(o => (string)property.GetValue(o, null))
                .Where(value => (bool)method.Invoke(value, new object[] { filter }))
                .Take(maxResults).ToArray();
        }
