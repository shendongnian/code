    public static string RemoveNonAlphanumeric(string text)
    {
        StringBuilder sb = new StringBuilder(text.Length);
        for (int i = 0; i < text.Length; i++)
            if (Char.IsLetterOrDigit(text[i]))
                sb.Append(text[i]);
        return sb.ToString();
    }
