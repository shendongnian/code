    var types = new List<string>{ "adcn", "adcn/adv" }; // etc
    foreach (var line in lines)
    {
        if (types.Any(t => t == line.Type.ToLower()))
        {
             Console.WriteLine(line);
        }
    }
