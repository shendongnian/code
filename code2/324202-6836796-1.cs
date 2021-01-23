    static void Main(string[] args)
    {
        var nbSystems = 2;
        var nbSteps = 3;
        var steps = GetSteps(0, 1, nbSteps).Select(n => Math.Round(n, 2)).ToArray();
        foreach (var seq in GetCombinations(steps, nbSystems))
            Console.WriteLine(string.Join(", ", seq));
    }
    private static IEnumerable<decimal> GetSteps(decimal min, decimal max, int count)
    {
        var increment = (max - min) / count;
        return Enumerable.Range(0, count + 1).Select(n => min + increment * n);
    }
    private static IEnumerable<IEnumerable<T>> GetCombinations<T>(
        ICollection<T> choices, int length)
    {
        if (length == 0)
        {
            yield return new T[0];
            yield break;
        }
        foreach (var choice in choices)
            foreach (var suffix in GetCombinations(choices, length - 1))
                yield return Enumerable.Concat(new[] { choice }, suffix);
    }
