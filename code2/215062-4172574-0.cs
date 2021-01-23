    public static IOrderedQueryable<Listing> WithListingOrder(this IQueryable<Listing> source, PriceOrderingOptions orderBy)
    {
       switch (orderBy)
       {
          case ListingOrderingOptions.Price:
             return source.OrderBy(x => x.Price);
          ... // other enumerations
       }
    }
