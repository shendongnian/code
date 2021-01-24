    static string ZigZag(string input, int level)
    {
        var indexMap = GenerateIncreasingDecreasing(level);
        var result =
                input.Select((c, i) => new { Char = c, Index = indexMap[i % (level + 1)] })
                    .GroupBy(x => x.Index)
                    .OrderBy(g => g.Key)
                    .SelectMany(x => x.Select(y => y.Char))
                    .ToArray();
        return new string(result);
    }
