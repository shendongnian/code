    private string Normalize(string text)
    {
            return string.Join("",
                from ch in text
                where char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)
                select ch);
    }
