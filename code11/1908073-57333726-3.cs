    public static IEnumerable<string> GetStrings(string input)
    {
       var state = 0;
       var sb = new StringBuilder();
       foreach (var c in input)
       {
          switch (state)
          {
             case 0:
                if (c != '#')
                {
                   sb.Append(c);
                   break;
                }
    
                if (sb.Length > 0)
                   yield return sb.ToString();
                  
                sb.Clear();
                state = 1;
    
                break;
             case 1:
                state = 2;
                break;
             case 2:
                if (c != '=')
                   state = 0;
                break;
          }
       }
    
       if (sb.Length > 0)
          yield return sb.ToString();   
    }
