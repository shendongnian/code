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
