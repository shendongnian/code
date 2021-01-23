    SortedDictionary<int, int> lengthDictionary = new SortedDictionary<int, int>();
    lengthDictionary.Add(1, 20);
    lengthDictionary.Add(2, 8);
    lengthDictionary.Add(3, 10);
    lengthDictionary.Add(4, 5);
    int runningSum = 0;
    var query = (from pair in lengthDictionary
                let innerSum = (runningSum += pair.Value)
                select new
                {
                    Key = pair.Key,
                    Value = innerSum 
                });
    foreach (var pair in query)
        Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
