    var first = new List<string> { "one", "two" };
    var second = new List<string> { "middle" };
    var third = new List<string> { "a", "b", "c", "d" };
    var all = new List<List<string>> { first, second, third };
    
    List<string> GetIds(List<List<string>> remaining)
    {
        if (remaining.Count() == 1) return remaining.First();
        else
        {
            var current = remaining.First();
            List<string> outputs = new List<string>();
            List<string> ids = GetIds(remaining.Skip(1).ToList());
    
            foreach (var cur in current)
                foreach (var id in ids)
                    outputs.Add(cur + " - " + id);
    
            return outputs;
        }
    }
    
    var names = GetIds(all);
    
    foreach (var name in names)
    {
        Console.WriteLine(name);
    }
    
    Console.Read();
