    public string SkipChars(string InputString, char[] CharsToSkip)
    {
      string result = InputString;
      foreach (var chr in CharsToSkip)
      {
        result = result.Replace(chr.ToString(), "");
      }
      return result;
    }
