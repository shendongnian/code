    const string input = "Hello World This is a great world, This World is simply great";
    var words = input
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Where(w => w.Length >= 3)
        .GroupBy(w => w)
        .Select(g => new { Word = g.Key, Count = g.Count() })
        .OrderByDescending(w => w.Count);
    
    foreach (var word in words)
        Console.WriteLine("{0}x {1}", word.Count, word.Word);
    
    // 2x World
    // 2x This
    // 2x great
    // 1x Hello
    // 1x world,
    // 1x simply
