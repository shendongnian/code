    public static IQueryable<T> GetAllByType<T>(
        this IQueryable<T> customQuery, string seller) where T : class, new()
    {
        return from i in customQuery
                    let prop = typeof(T).GetProperty("SellerType")
                    where prop != null && prop.GetValue(i, null).Equals(seller) 
                    select i;
    }
