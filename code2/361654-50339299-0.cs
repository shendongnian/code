    static void Main(string[] args)
    {
        foreach (var vals in Combos(new[] { "0", "1", "2", "3" }).Where(v => v.Skip(1).Any() && !v.Skip(2).Any()))
            Console.WriteLine(string.Join(", ", vals));
    }
    static IEnumerable<IEnumerable<T>> Combos<T>(T[] arr)
    {
        IEnumerable<T> DoQuery(long j, long idx)
        {
            do
            {
                if ((j & 1) == 1) yield return arr[idx];
            } while ((j >>= 1) > 0 && ++idx < arr.Length);
        }
        for (var i = 0; i < Math.Pow(2, arr.Length); i++)
            yield return DoQuery(i, 0);
    }
