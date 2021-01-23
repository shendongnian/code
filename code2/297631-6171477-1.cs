    Dictionary<char, char> mappings;
    static public string Translate(string s)
    {
       var t = new StringBuilder(s.Length);
       foreach (char c in s)
       {
          char to;
          if (mappings.TryGetValue(c, out to))
             t.Append(to);
          else
             t.Append(c);
        }
        return t.ToString();
     }
       
