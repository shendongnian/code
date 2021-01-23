    Regex ItemRegex = new Regex(@"(?<=PREF-).*$",  RegexOptions.Compiled);
    foreach (Match ItemMatch in ItemRegex.Matches(subjectString))
    {
        Console.WriteLine(ItemMatch);
    }
