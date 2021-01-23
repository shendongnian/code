    var bestSubSequence = listOfInts.Skip(1).Aggregate(
        Tuple.Create(int.MinValue, new List<int>(), new List<int>()),
        (curr, next) =>
            {
                var bestList = curr.Item2.Count > curr.Item3.Count ? curr.Item2 : curr.Item3;
                if (curr.Item1 > next)
                    return Tuple.Create(next, new List<int> {next}, bestList);
                curr.Item2.Add(next);
                return Tuple.Create(next, curr.Item2, bestList);
            }).Item3;
