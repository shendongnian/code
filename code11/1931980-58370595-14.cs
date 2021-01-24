    private static IEnumerable<int> PinnedSort(IEnumerable<int> numbers, ISet<int> pinnedNumbers)
    {
        var onlyPinnedNumbers = new List<ValueTuple<int, int>>();
        var otherNumbers = new List<int>();
        // Iterate the numbers list once and construct both above lists
        for (var i = 0; i < numbers.Count(); i++)
        {
            (int number, int index) pair = (numbers[i], i);
            if (pinnedNumbers.Contains(pair.number))
            {
                onlyPinnedNumbers.Add(pair);
            } else
            {
                otherNumbers.Add(pair.number);
            }
        }
        // Sort other numbers
        var sortedNumbers = otherNumbers
            .OrderBy(number => number)
            .ToList();
        // Insert pinned numbers into sorted list
        foreach (var (number, index) in onlyPinnedNumbers)
        {
            sortedNumbers.Insert(index, number);
        }
        return sortedNumbers;
    }
