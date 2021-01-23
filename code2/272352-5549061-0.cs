    string input = "plum--pear";
    string pattern = "-";            // Split on hyphens
    
    string[] substrings = Regex.Split(input, pattern);
    foreach (string match in substrings)
    {
       Console.WriteLine("'{0}'", match);
    }
