namespace TechTalk.SpecFlow
{
    public static string ToIdentifierPart(this string text)
    {
        text = firstWordCharRe.Replace(text, match => match.Groups["pre"].Value + match.Groups["fc"].Value.ToUpper());
        // --- add this line ---
        text = text.Replace(" ", "_");   
        text = punctCharRe.Replace(text, "_");
        text = RemoveAccentChars(text);
        if (text.Length > 0)
            text = text.Substring(0, 1).ToUpper() + text.Substring(1);
        return text;
    }
}
