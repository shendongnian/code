    List<string> list = new List<string>()
    {
        "Red",
        "Blue",
        "Green"
    };
    
    string output = string.Join(Environment.NewLine, list.ToArray());    
    Console.Write(output);
