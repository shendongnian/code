    string names = "smith;rodgers;McCalne";
    
    List<string> split = names.Aggregate(new string[] { string.Empty }.ToList(), (s, c) => {
      if (c == ';') s.Add(string.Empty); else s[s.Count - 1] += c;
      return s;
    });
