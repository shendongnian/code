    var matchingPeopele = personQueue.Where(p => p.name == personStruct.name);
    if (matchingPeopele.Any())
    {
        var match = matchingPeopele.First();
        Console.WriteLine(match.name);
        Console.WriteLine(match.bday);
        Console.WriteLine(match.age);
    }
    else
    {
        Console.WriteLine("Doesn't exist!");
    }
