    // If you want duplicates in Numbers to still come up as duplicates in the result
    HashSet<int> blacklistedSet = new HashSet<int>(blackListedNumbers);
    List<int> finalList = Numbers.AsParallel()
                                 .Where(x => !blacklistedSet.Contains(x))
                                 .ToList();
    // Or if you just want a set-based operation:
    List<int> finalList = Numbers.AsParallel()
                                 .Except(blacklistedSet)
                                 .ToList();
