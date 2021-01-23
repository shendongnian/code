    /// <summary>
    /// Uses regex '\b' as suggested in https://stackoverflow.com/questions/6143642/way-to-have-string-replace-only-hit-whole-words
    /// </summary>
    /// <param name="original"></param>
    /// <param name="wordToFind"></param>
    /// <param name="replacement"></param>
    /// <param name="regexOptions"></param>
    /// <returns></returns>
    static public string ReplaceWholeWord(this string original, string wordToFind, string replacement, RegexOptions regexOptions = RegexOptions.None)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);
        return Regex.Replace(original, pattern, replacement, regexOptions);;
    }
