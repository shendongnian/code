    string mystring = "[asda$@.asd ' a12876 ]] \"\" ]";
    Console.WriteLine(mystring);
    MatchCollection matches = 
       Regex.Matches(mystring,
                     @"[\w@#](?:[\w\.\$@#])*|\[[\w@#](?:\[\[|\]\]|[""\w\s\.\$@#'])*\]|""[\w@#](?:\""\""|['\s\[\w\.\$@#\]])*""",
                     RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
    foreach (Match match in matches)
    {
       string id = match.Value;
       // The first character of the match tells us which escape sequence to use
       // for the replacement.
       if (match.Value[0] == '[')
          id = id.Substring (1, id.Length - 2).Replace ("[[", "[").Replace ("]]", "]");
       else if (match.Value[0] == '"')
          id = id.Substring (1, id.Length - 2).Replace ("\"\"", "\"");
       Console.WriteLine (id);
    }
