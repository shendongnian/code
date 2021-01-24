    using System.Numerics;
    public static IEnumerable<(T[], T[])> GetCollectionPairs<T>(T[] source)
    {
        BigInteger combinations = BigInteger.One << source.Length;
        for (BigInteger i = 0; i < combinations; i++)
        {
            yield return
            (
                Enumerable.Range(0, source.Length)
                .Where(j => (i & (BigInteger.One << j)) != 0)
                .Select(j => source[j])
                .ToArray(),
                Enumerable.Range(0, source.Length)
                .Where(j => (i & (BigInteger.One << j)) == 0)
                .Select(j => source[j])
                .ToArray()
            );
        }
    }
