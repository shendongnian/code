    String str = @"a
    b
    c
    d
    e";
    int n = 2;
    string[] lines = str
        .Split(Environment.NewLine.ToCharArray())
        .Skip(n)
        .ToArray();
    string output = string.Join(Environment.NewLine, lines);
    // Output is 
    // "c
    // d
    // e"
