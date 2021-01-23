    /// <summary>Returns a collection containing all consecutive sequences of
    /// integers in the input collection.</summary>
    /// <param name="input">The collection of integers in which to find
    /// consecutive sequences.</param>
    /// <param name="minLength">Minimum length that a sequence should have
    /// to be returned.</param>
    static IEnumerable<IEnumerable<int>> ConsecutiveSequences(
        IEnumerable<int> input, int minLength = 1)
    {
        var arr = input.OrderBy(x => x).ToArray();
        var results = new List<List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            var existing = results.FirstOrDefault(lst => lst.Last() + 1 == arr[i]);
            if (existing == null)
                results.Add(new List<int> { arr[i] });
            else
                existing.Add(arr[i]);
        }
        return minLength <= 1 ? results :
            results.Where(lst => lst.Count >= minLength);
    }
