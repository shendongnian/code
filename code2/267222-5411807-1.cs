    public static bool Equals<TKey, TValue>(IDictionary<TKey, TValue> x, 
        IDictionary<TKey, TValue> y)
    {
        return x.Keys.Intersect(y.Keys).Count == x.Keys.Count &&
            x.Keys.All(key => Object.Equals(x[key], y[key]));
    }
