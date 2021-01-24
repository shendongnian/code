    var duplicatedNamesAndBirthdate = persons
        .GroupBy(p => new { p.FirstName, p.LastName, p.BirthDate })
        .Where(g => g.Count() > 1)
        .ToDictionary(
            g => g.Key,        
            g => g.ToArray()
        );
    foreach (var pair in duplicatedNamesAndBirthdate)
    {
        Console.WriteLine(@$"{pair.Value.Length} people have the duplicated info: 
    FirstName={pair.Key.FirstName}, 
    LastName={pair.Key.LastName}, 
    BirthDate={pair.Key.BirthDate}.");
    }
