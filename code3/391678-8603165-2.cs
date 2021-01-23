    private static IEnumerable<MyData> GetTop2Names(IEnumerable<MyData> data)
    {
        var top2 = data.GroupBy(d => d.Name)
                       .OrderByDescending(g => g.Sum(d => d.Quantity))
                       .Take(2)
                       .Select(g => g.Key);
        return data.Where(d => top2.Contains(d.Name));
    }
