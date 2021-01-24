    string x = "Resource:resource1:resource2";
    string y = "writer";
    List<string> roles;
    List<string> words   = new List<string> { x, y };
    // We are using escape to search for multiple strings.
    string       pattern = string.Join("|", words.Select(w => Regex.Escape(w)));
    Regex        regex   = new Regex(pattern, RegexOptions.IgnoreCase);
    // You got matched results...
    List<string> matchedResults = roles.Where(regex.IsMatch).ToList();
