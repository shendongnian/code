    You could compose existing operators like this,
    
        IEnumerable<IEnumerable<int>> myInts = new List<IEnumerable<int>>()
                    {
                      Enumerable.Range(1, 20).ToList(),
                      Enumerable.Range(21, 5).ToList(),
                      Enumerable.Range(26, 15).ToList()
                    };
    
        myInts.SelectMany(item => item.Select((number, index) => Tuple.Create(index, number))
              .GroupBy(item => item.Item1)
              .Select(group => group.Select(tuple => tuple.Item2));
