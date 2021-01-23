    var types = new List<string>{ "adcn", "adcn/adv" }; // etc
    foreach (var line in lines.Where(line => types.Any(t => t == line.Type.ToLower())))
    {
         Console.WriteLine(line);
    }
