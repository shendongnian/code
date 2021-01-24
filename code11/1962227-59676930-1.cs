    public static string ReplaceAll(
      string str, char[] charsToReplace, char replacementCharacter) {
      if (string.IsNullOrEmpty(str) || null == charsToReplace || charsToReplace.Length <= 0)
        return str;
      return Regex.Replace(
         str,
        $"[{Regex.Escape(new String(charsToReplace))}]+",
         m => new string(replacementCharacter, m.Length));
    }
