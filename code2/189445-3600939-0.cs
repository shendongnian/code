    public OrderByFunc<TSource, TKey> GetOrderByFunc<TSource, TKey>(bool descending)
    {
        if (descending)
        {
            return Enumerable.OrderByDescending;
        }
        else
        {
            return Enumerable.OrderBy;
        }
    }
