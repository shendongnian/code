    string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
    
    var upperLowerWords = from w in words
                            select new
                            {
                                Upper = w.ToUpper(),
                                Lower = w.ToLower(),
                                Original = w,
                                Changed = new string(w.Select(s=> char.IsLower(s) ? char.ToUpper(s) : char.ToLower(s)).ToArray())
                            };
    
    foreach (var ul in upperLowerWords)
    {
        Console.WriteLine("Original: {0}, Uppercase: {1}, Lowercase: {2}, Changed: {3}", ul.Original, ul.Upper, ul.Lower, ul.Changed );
    }
