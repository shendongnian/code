    var types = new List<string>{ "adcn", "adcn/adv" }; // etc
    if (types.Any(t => t == line.Type.ToLower()))
    {
         Console.WriteLine(line);
    }
