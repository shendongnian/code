    var numbers = new int[] { 33, 20, 48, 17, 48, 36, 20, 12, 25 };
    var pinnedNumbers = new HashSet<int> { 20, 25 };
    // Extract pinned numbers into tuple (number, index)
    var onlyPinnedNumbers = new List<Tuple<int, int>>();
    for (var i = 0; i < numbers.Count(); i++)
    {
        if (pinnedNumbers.Contains(numbers[i]))
        {
            onlyPinnedNumbers.Add(Tuple.Create(numbers[i], i));
        }
    }
    // Sort other numbers
    var sortedNumbers = numbers
        .Where(x => !pinnedNumbers.Contains(x))
        .OrderBy(x => x)
        .ToList();
    // Insert pinned numbers into sorted list
    foreach (var pinned in onlyPinnedNumbers)
    {
        sortedNumbers.Insert(pinned.Item2, pinned.Item1);
    }
    # Print out list
    Console.WriteLine("{" + string.Join(", ", sortedNumbers) + "}");
