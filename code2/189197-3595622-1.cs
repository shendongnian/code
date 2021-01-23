    public static string TrimInternal(this string text)
    {
      var trimmed = text.Where((c, index) => !char.IsWhiteSpace(c) || (index != 0 && !char.IsWhiteSpace(text[index - 1])));
      return new string(trimmed.ToArray());
    }
