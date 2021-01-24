 c#
    public static decimal TotalPrices (this IEnumerable<Product> products)
    {
        decimal total = 0;
        using (var iter = products.GetEnumerator())
        {
            while (iter.MoveNext())
            {
                var prod = iter.Current;
                total += prod?.Price ?? 0;
            }
        }
        return total;
    }
which is all defined via `IEnumerable<T>`. The good news is: you **usually** never need to know this - just know that `foreach` works on sequences, and `IEnumerable<T>` is a sequence of `T`.
