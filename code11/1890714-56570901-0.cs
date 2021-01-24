    var summaries = listAssy
        .Select(a => new {
            a.id,
            a.title,
            partQuantities = a.listParts.GroupBy(p => new { p.id, p.title })
                .Select(g => new { g.Key.id, g.Key.title, qty = g.Sum(p => p.qty)})
                .ToList()
        });
    
    foreach (var assy in summaries)
    {
        Console.WriteLine("[" + assy.title + "]");
        foreach (var part in assy.partQuantities)
        {
            Console.WriteLine("  [" + part.qty + "] " + part.title);
        }
        Console.WriteLine("");
    }
