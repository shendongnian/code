    public static IEnumerable<string> GetStrings(string input)
    {
       var state = 0;
       var sb = new StringBuilder();
    
       foreach (var c in input)
       {
          if (state == 0 && c != '#')
             sb.Append(c);
          if (state == 0)
          {
             if (sb.Length > 0) yield return sb.ToString();
             sb.Clear();
             state = 1;
          }
          if (state == 1) 
              state = 2;
          else if (c != '=') 
              state = 0;
       }
    
       if (sb.Length > 0) yield return sb.ToString();
    }
