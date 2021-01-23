    public static string RemoveLast(this string text, string character)
    {
        if(text.Length < 1) return text;
        return text.Remove(text.ToString().LastIndexOf(character), character.Length);
    }
