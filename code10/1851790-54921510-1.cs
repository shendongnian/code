    public static string CapitalizeLetter(this string value) {
      // Do not forget to validate public methods' input
      if (string.IsNullOrEmpty(value))
        return value;
      // We know the size of string we want to build - value.Length 
      StringBuilder sb = new StringBuilder(value.Length);
      bool toUpper = true;
      foreach (var c in value) {
        char add = c;
        if (char.IsWhiteSpace(c) || c == '.')
          toUpper = true;
        else {
          if (char.IsLetter(c))
            add = toUpper ? char.ToUpper(c) : char.ToLower(c);
          toUpper = false;
        }
        sb.Append(add);
      }
      return sb.ToString();
    }
