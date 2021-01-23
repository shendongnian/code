    int runningSum = 0;
    var query = (from pair in lengthDictionary
                let innerSum = (runningSum += pair.Value)
                select new
                {
                    Key = pair.Key,
                    Value = innerSum 
                });
    // make a new SortedDictionary?
    var newDictionary = new SortedDictionary<int, int>(query.ToDictionary(pair => pair.Key, pair => pair.Value));
    // display to confirm result
    foreach (var pair in newDictionary)
        Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
