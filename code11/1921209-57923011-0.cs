    static string ReturnMaxOccurences(string source, int count)
    {
        return source.Aggregate(new Accumulator(), (acc, c) =>
        {
            acc.Histogram.TryGetValue(c, out int charCount);
            if (charCount < count)
                acc.Result.Append(c);
            acc.Histogram[c] = ++charCount;
            return acc;
        }, acc => acc.Result.ToString());
    }
