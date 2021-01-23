    public static bool Equals<TKey, TValue>(IDictionary<TKey, TValue> x, 
        IDictionary<TKey, TValue> y)
    {
        return x.Keys.Intersect(y.Keys).Count == x.Keys &&
            x.Keys.All(key => x[key] == y[key]);
    }
