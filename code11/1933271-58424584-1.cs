c#
static void Main(string[] args)
{
    string input = "flour*yeast*banana";
    string[] searchblock = new string[4] { "flouryeastbanana", "flouraddyeastmashbanana", "flouraddyeastbanana", "yeastflourbanana" };
    string pattern = input.Replace("*", ".*?");
    foreach (string s in searchblock)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(s, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            Console.WriteLine($"input \"{s}\":  (match for '{pattern}' found)");
        }
    }
}
The sequence `".*?"` in the regex says to match any number of any character, with the least number of characters possible that will still allow the match to succeed. By using it in place of your marker in the input string, that allows any string with your non-marker strings separated by any other characters to match.
Note that the `?` in the string is probably optional in your case. It would make a subtle difference with respect to where the matches occurred if you presented the pattern with strings that included the non-marker strings multiple time, but shouldn't affect _whether_ the strings actually matched or not. So if you prefer, you could probably just use `".*"` as the replacement text instead of `".*?"`.
