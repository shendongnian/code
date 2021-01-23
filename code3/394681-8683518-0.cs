    public static class ExtnensionsForIQueryableCustomer
    {
        public static IEnumerable<Customer> WhereActiveWithAddressAndNamed (this IQueryable<Customer> queryable, string name)
        {
            return queryable.Where (c => c.FirstName == name)
                            .Where (c => c.IsActive)
                            .Where (c => c.HasAddress);
        }
    }
