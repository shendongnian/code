    // will contain all contiguous subsets 
    var sequences = new List<Tuple<bool, List<int>>>();
    // build subsets 
    foreach (int item in source)
    {
        var deadCopies = new List<Tuple<bool, List<int>>>();
        foreach (var record in sequences.Where(r => r.Item1 && !r.Item2.Contains(0)))
        {
            // make a copy that is "dead"
            var deadCopy = new Tuple<bool, List<int>>(false, record.Item2.ToList());
            deadCopies.Add(deadCopy);
            record.Item2.Add(item);
        }
        sequences.Add(new Tuple<bool, List<int>>(true, new List<int> { item }));
        sequences.AddRange(deadCopies);
    }
