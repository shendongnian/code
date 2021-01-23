    static public string UpperCaseFirstCharacter(this string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            return string.Format(
                "{0}{1}",
                text.Substring(0, 1).ToUpper(),
                text.Substring(1));
        }
        return text;
    }
