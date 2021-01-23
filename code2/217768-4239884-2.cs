    var list = new List<string> { "A.B.D", "A", "A.B","E","F.E", "F","B.C", "B.C.D" };
    var result = list.OrderBy(s => s)
                     .GroupBy(s => s[0])
                     .Select(g => g.First());
    
    foreach (var s in result)
    {
        Console.WriteLine(s);
    }
