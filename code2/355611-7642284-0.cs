    string pattern = @"\b[at]\w+";
    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
    string text = "The threaded application ate up the thread pool as it executed.";
    MatchCollection matches;
    
    Regex optionRegex = new Regex(pattern, options);
    Console.WriteLine("Parsing '{0}' with options {1}:", text, options.ToString());
    // Get matches of pattern in text
    matches = optionRegex.Matches(text);
    // Iterate matches
    for (int ctr = 1; ctr <= matches.Count; ctr++)
       Console.WriteLine("{0}. {1}", ctr, matches[ctr-1].Value);
