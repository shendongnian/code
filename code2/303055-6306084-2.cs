    var input = "Şöme-p@ttern"; // text to convert into a slug
    var replaces = new Dictionary<char, char> { { '@', 'a' } }; // list of chars you care
    var pattern = @"[^A-Z0-9_-]+"; // regex to remove invalid characters
    
    var result = new StringBuilder(RemoveDiacritics(input, false)); // convert Ş to S
                                                                    // and so on
    
    foreach (var item in replaces)
    {
        result = result.Replace(item.Key, item.Value); // replace @ with a and so on
    }
    
    // remove invalid characters which weren't converted
    var slug = Regex.Replace(result.ToString(), pattern, String.Empty,
        RegexOptions.IgnoreCase);
    // output: Some-pattern
