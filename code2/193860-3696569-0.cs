    // get the order somehow
    string order = ...;
    
    var lines = order.Split('\'');     // splits at the apostrophe character
    foreach (var line in lines)
    {
        var pieces = line.Split('+', ':');    // splits at both of those characters
        DoSomething(pieces);
    }
