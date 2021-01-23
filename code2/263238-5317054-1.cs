    string input = "languages";
    var query = input.Select((c, i) => new { Char = c, Index = i })
                     .Where(o => Char.IsLetter(o.Char))
                     .GroupBy(o => o.Char)
                     .Select(g => g.First());
    foreach (var item in query)
    {
        Console.WriteLine("{0}: {1}", item.Char, item.Index);
    }
