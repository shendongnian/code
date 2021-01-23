    public bool IsSpecialChar(char c) {
      // Need you to fill this out
    }
    
    public string RemoveSpecialChars(string s) {
      var builder = new System.Text.StringBuilder();
      foreach (var cur in s) {
        if (!IsSpecialChar(cur)) {
          builder.Append(cur);
        }
      }
      return builder.ToString();
    }
