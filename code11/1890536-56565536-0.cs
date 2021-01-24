    var working = "name test +company abc def +phone 3434 +vehicle test + interested yyy +invited zzz";
    if (System.Text.RegularExpressions.Regex.IsMatch(working, "[^a-zA-Z0-9 +]"))
    {
        throw new InvalidOperationException();
    }
    var values = working.Split('+').Select(x => x?.Trim() ?? string.Empty);
    foreach (var phrase in values)
    {
        string left, right;
        
        var space = phrase.IndexOf(' ');
        if (space > 0)
        {
            left = phrase.Substring(0, space)?.Trim() ?? string.Empty;
            right = phrase.Substring(space + 1, phrase.Length - space - 1)?.Trim() ?? string.Empty;
            
            Console.WriteLine("left: [" + left + "], right: [" + right + "]");
        }
    }
