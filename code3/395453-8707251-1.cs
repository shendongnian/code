    const string input = "Hello World This is a great world, This World is simply great";
    var words = input
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Where(w => w.Length >= 3)
        .GroupBy(w => w)
        .OrderByDescending(g => g.Count());
    
    foreach (var word in words)
        Console.WriteLine("{0}x {1}", g.Count(), word.Key);
    
    // 2x World
    // 2x This
    // 2x great
    // 1x Hello
    // 1x world,
    // 1x simply
