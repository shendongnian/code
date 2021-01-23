    class Aggregator
    {
        public List<int> List { get; set; }
        public int Sum { get; set; }
    }
..
    var seq = new List<int> { 1, 3, 12, 19, 33 };
    var aggregator = new Aggregator{ List = new List<int>(), Sum = 0 };
    var aggregatorResult = seq.Aggregate(aggregator, (a, number) => { a.Sum += number; a.List.Add(a.Sum); return a; });
    var result = aggregatorResult.List;
