    /// <summary>Returns a collection containing all consecutive sequences of
    /// integers in the input collection.</summary>
    /// <param name="input">The collection of integers in which to find
    /// consecutive sequences.</param>
    /// <param name="minLength">Minimum length that a sequence should have
    /// to be returned.</param>
    static IEnumerable<IEnumerable<int>> ConsecutiveSequences(
        IEnumerable<int> input, int minLength = 1)
    {
        var results = new List<List<int>>();
        foreach (var i in input.OrderBy(x => x))
        {
            var existing = results.FirstOrDefault(lst => lst.Last() + 1 == i);
            if (existing == null)
                results.Add(new List<int> { i });
            else
                existing.Add(i);
        }
        return minLength <= 1 ? results :
            results.Where(lst => lst.Count >= minLength);
    }
