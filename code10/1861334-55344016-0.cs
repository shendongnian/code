    var groupedLocation = locationOutputDistinct.GroupBy(x => new string(x.Where(c => !char.IsDigit(c)).ToArray()))
                                                .OrderByDescending(x => x.Key.Length)
                                                .ToList();
    foreach(var group in groupedLocation)
    {
        var maxSum = group.Max(x => x.Where(c => char.IsDigit(c))
                          .Select(z => char.GetNumericValue(z)).Sum());
        var matchingRecord = group.FirstOrDefault(x => x.Where(c => char.IsDigit(c)).Select(z => char.GetNumericValue(z)).Sum() == maxSum);
        Console.WriteLine(matchingRecord);
    }
