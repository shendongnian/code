csharp
class ResultItem {
    public string Name { get; set; }
    public double Value { get; set; }
}
class ResultGroup {
    public string Name { get; set; }
    public ResultItem[] Data { get; set; }
}
var results = items
    .GroupBy(x => x.Category[0])
    .Select(g => new ResultGroup {
        Name = g.Key,
        Data = g
            .GroupBy(x => x.Category[1])
            .Select(g2 => new ResultItem { Name = g2.Key, Value = g2.Sum(x => x.Cost) })
            .ToArray()
        });
