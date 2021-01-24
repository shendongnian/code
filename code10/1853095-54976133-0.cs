private const string _usernamePattern = "Username: <strong>(?<Email>.*)</strong>";
...
private string Grab(string text, string pattern)
{
    var match = Regex.Match(text, pattern);
    if (!match.Success)
        throw new Exception();
    else
        return match.Groups["Email"].Value;
}
