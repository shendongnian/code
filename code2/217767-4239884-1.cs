    var list = new List<string> { "A", "A.B.D", "A", "A.B", "E", "F.E", "F", "B.C" };
    var result = list.GroupBy(s => s[0])
                     .Select(g => g.Count() > 1 ? g.Key.ToString() : g.Single());
    
    foreach (var s in result)
    {
        Console.WriteLine(s);
    }
