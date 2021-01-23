    public static class ProductFilters
    {
        public static IQueryable<Products> NiceMan(
            this IQueryable<Products> customQuery, string filterName)
        {
            if (!string.IsNullOrEmpty(filterName))
               customQuery = customQuery.Where(u => u.Name == filterName);
            return customQuery;
        }
       // create lots of other Products based filters here
       // and repeat with seperate IQueryable<Classes> per type
    }
