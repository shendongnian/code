    Regex ItemRegex = new Regex(@"(?<=PREF-).*$",  RegexOptions.Singleline | 
                                                     RegexOptions.Multiline).Value);
    foreach (Match ItemMatch in ItemRegex.Matches(subjectString))
    {
        Console.WriteLine(ItemMatch);
    }
