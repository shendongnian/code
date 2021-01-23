    using System.Text.RegularExpressions;
    ...
    string input = GetArticle(); // or however you get your input
    
    // clean up words from punctuation
    input = Regex.Replace(input, @"[^0-9\w\s]", string.Empty);
    
    // trim whitespace
    input = Regex.Replace(c, @"\s+", @" ");
    
    var errors = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).All(w => !_spellChecker.CheckWord(w));
