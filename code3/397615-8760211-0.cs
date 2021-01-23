    private static Random Generator = new Random();
    
    private IEnumerable GetSubjects()
    {
        var results = (from r in sc.Subjects where (r.SubName == sub && r.Level == lev) select r).ToList();
        var indexes = new HashSet<int>();
        while (indexes.Count < 10 && indexes.Count < results.Count)
        {
            indexes.Add(Generator.Next(results.Count));
        }
        for (var index in indexes) yield return results[index];
    }
