    using System.Linq;
    ...
    public static string ToLiteral(string input) {
      if (null == input)
        return null;
 
      StringBuilder sb = new StringBuilder();
      foreach (var c in input) {
        if (char.IsControl(c))
          sb.Append($"\\u{((int)c):x4}");
        else {
          if (c == '"' || c == '\\') // escapement 
            sb.Append('\\'); 
          sb.Append(c);
        } 
      }
      return sb.ToString();  
    }
