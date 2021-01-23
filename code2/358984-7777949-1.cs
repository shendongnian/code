    public static class MyQueryExtensions
    {
        public static IQueryable<Product> WhereIsShipped(
            this IQueryable<Product> query)
        {
            return query.Where(p => p.ShippingDate.HasValue && p.ShippedQuantity >0);
        }
    }
