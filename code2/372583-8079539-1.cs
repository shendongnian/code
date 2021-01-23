    var names = new List<string>(
        File.ReadAllText(pathToFile).Split(
        Environment.NewLine.ToCharArray(),
        StringSplitOptions.RemoveEmptyEntries
    ));
    var namesAndOccurrences =
        from name in names.Distinct()
        select name + " " + names.Count(n => n == name);
    foreach (var name in namesAndOccurrences)
        Console.WriteLine(name);
