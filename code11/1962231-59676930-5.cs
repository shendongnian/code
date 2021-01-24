    public static string ReplaceAll(
      string str, char[] charsToReplace, char replacementCharacter) {
      if (string.IsNullOrEmpty(str) || null == charsToReplace || charsToReplace.Length <= 0)
        return str;
      string charsSet = string.Concat(charsToReplace
        .Select(c => new char[] { ']', '-' }.Contains(c) // in case of '-' and ']'
           ? $@"\{c}"                                    // escape them as well
           : Regex.Escape(c.ToString())));
      return Regex.Replace(
         str,
        $"[{charsSet}]+",
         m => new string(replacementCharacter, m.Length));
    }
