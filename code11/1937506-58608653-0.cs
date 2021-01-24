public static class MyStringExtension
{
    public static string ReplaceHTMLTags(this string text)
    {
        return Regex.Replace(text, "<.*?>", String.Empty);
    }
}
this will allow you to chain them together like 
text.ReplaceHTMLTags().ReplaceNumeric().ReplaceSpecialCharacters()
