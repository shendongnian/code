    public static class QueryExtensions
    {
        public static Customer GetByKey(this IQueryable<Customer> query, int customerId,string customerName)
        {
            return query.FirstOrDefault(a => a.CustomerId == customerId && a.CustomerName == customerName);
        }
    
    }
