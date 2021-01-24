    Regex regex = new Regex(@"\s\([^\(\)]+\)(?=,)");
    
    var inputs = new[] {
        "Dog (small) (brown), 1",
        "Dog (medium) (black), 1",
        "Dog (big), 0"
    };
    
    foreach (var input in inputs)
        Console.WriteLine(regex.Replace(input, ""));
    // will output:
    // Dog (small), 1
    // Dog (medium), 1
    // Dog, 0
