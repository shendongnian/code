    /// <summary>
    /// String.Split with RemoveEmptyEntries option for clean up empty entries from result
    /// </summary>
    /// <param name="s">Value to parse</param>
    /// <param name="separator">The separator</param>
    /// <param name="index">Hint: pass -1 to get Last item</param>
    /// <param name="wholeResult">Get array of split value</param>
    /// <returns></returns>
    public static object CleanSplit(this string s, char separator, int index, bool wholeResult = false)
    {
        if (string.IsNullOrWhiteSpace(s)) return "";
        var split = s.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        if (wholeResult) return split;
        if (index == -1) return split.Last();
        if (split[index] != null) return split[index];
        return "";
    }
