    private static IEnumerable<string> Parse(string formula) {
      int state = 0;
    
      StringBuilder buffer = new StringBuilder();
    
      foreach (var c in formula) {
        if (state == 0) { // neither var nor number
          if (char.IsWhiteSpace(c))
            continue;
    
          if (char.IsDigit(c)) {
            buffer.Append(c);
            state = 2;
          }
          else if (char.IsLetter(c)) {
            buffer.Append(c);
            state = 1;
          } 
          else 
            yield return c.ToString();
        }
        else if (state == 1) { // within variable
          if (char.IsDigit(c) || char.IsLetter(c))
            buffer.Append(c);
          else {
            yield return buffer.ToString();
            buffer.Clear(); 
    
            state = 0;
    
            if (!char.IsWhiteSpace(c))
              yield return c.ToString();
          }
        }
        else if (state == 2) { // within number
          if (char.IsDigit(c))
            buffer.Append(c);
          else if (char.IsLetter(c)) {
            // 123abc we turn into 123 * abc
            yield return buffer.ToString();
            buffer.Clear();
    
            state = 1; 
    
            yield return "*";
    
            buffer.Append(c);
          }
          else {
            yield return buffer.ToString();
            buffer.Clear();
    
            state = 0;
    
            if (!char.IsWhiteSpace(c))
              yield return c.ToString();
          } 
        }
      } 
    
      if (buffer.Length > 0)
        yield return buffer.ToString();
    }
