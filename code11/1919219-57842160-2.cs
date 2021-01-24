    using System.Numerics;
    public static IEnumerable<IEnumerable<T>> GetDistinctGroupedByOrigin<T>(
        IEnumerable<IEnumerable<T>> source)
    {
        return source.SelectMany((s, i) => s.Select(e => (Element: e, Index: i)))
            .GroupBy(e => e.Element)
            .Select(g => (Element: g.Key, Signature: g.Aggregate(
                BigInteger.Zero, (acc, e) => acc + (BigInteger.One << e.Index))))
            .GroupBy(e => e.Signature, e => e.Element);
    }
