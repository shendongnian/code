    string sentence = "We both arrived at the garage this morning";
    string search = "ar";
    // word boundary, optional characters, search term, optional characters again, word boundary.
    string regex = @"\b\w*(" + search + @")\w*\b";
    // find words matching the search term
    var foundWords = Regex.Matches(sentence, regex)
        .Cast<Match>()
        .Select(match => match.Value)
        .ToList();
    
    List<string> result = null;
    if (foundWords.Count == 0)
    {
        // If no words were found, use the original sentence.
        result = new List<string> { sentence };
    }
    else
    {
        // Create a split term containing the found words.
        var splitTerm = string.Join('|', foundWords.Select(w => "(" + w + ")"));
    
        // Split the sentence on the found words and trim the parts from spaces.
        result = Regex.Split(sentence, splitTerm)
            .Select(part => part.Trim())
            .ToList();
    }
    
    foreach (var part in result)
    {
        Console.WriteLine(part);
    }
