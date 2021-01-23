    public static class CountryFilters
    {
        public static IQueryable<Country> ThatContainsName(this IQueryable<Country> query, string country)
        {
            return query.Where(y => y.Name.ToLower().Contains(country.ToLower()));
        }
    }
