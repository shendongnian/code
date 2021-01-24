csharp
using System.Text; // used for StringBuilder, a better string concatenation than myStr += "content"
using System.Text.RegularExpressions;
public static class JsonUtil
{
    public static string Beautify(string json)
    {
        const int indentWidth = 4;
        const string pattern = "(?>([{\\[][}\\]],?)|([{\\[])|([}\\]],?)|([^{}:]+:)([^{}\\[\\],]*(?>([{\\[])|,)?)|([^{}\\[\\],]+,?))";
        var match = Regex.Match(json, pattern);
        var beautified = new StringBuilder();
        var indent = 0;
        while (match.Success)
        {
            if (match.Groups[3].Length > 0)
                indent--;
            beautified.AppendLine(
                new string(' ', indent * indentWidth) +
                (match.Groups[4].Length > 0
                    ? match.Groups[4].Value + " " + match.Groups[5].Value
                    : (match.Groups[7].Length > 0 ? match.Groups[7].Value : match.Value))
            );
            if (match.Groups[2].Length > 0 || match.Groups[6].Length > 0)
                indent++;
            match = match.NextMatch();
        }
        return beautified.ToString();
    }
}
To use it: `var beautifiedJson = JsonUtil.Beautify(json);`
It may not be the best solution in terms of performance but it worked perfectly for my use ^^
If you have a better one please take the time to share it ;)
