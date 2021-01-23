    string[] pats = { "å", "Å", "æ", "Æ", "ä", "Ä", "ö", "Ö", "ø", "Ø" ,"è", "È", "à", "À", "ì", "Ì", "õ", "Õ", "ï", "Ï" };
    string[] repl = { "a", "A", "a", "A", "a", "A", "o", "O", "o", "O", "e", "E", "a", "A", "i", "I", "o", "O", "i", "I" };
    // using Zip as a shortcut, otherwise setup dictionary differently as others have shown
    var dict = pats.Zip(repl, (k,v) => new { Key = k, Value = v }).ToDictionary(o => o.Key, o => o.Value);
    
    string input = "åÅæÆäÄöÖøØèÈàÀìÌõÕïÏ";
    string pattern = String.Join("|", pats);
    string result = Regex.Replace(input, pattern, m => dict[m.Value]);
    
    Console.WriteLine("Pattern: " + pattern);
    Console.WriteLine("Input: " + input);
    Console.WriteLine("Result: " + result);
