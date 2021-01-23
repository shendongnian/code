    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    ...
    private string HexToStringMatchEvaluator(Match match)
    {
        int intValue = int.Parse(match.Groups[1].Value, NumberStyles.AllowHexSpecifier);
        return Convert.ToChar(intValue).ToString();
    }
    ...
    string source = "ab\\x01c";
    source = Regex.Replace(source, @"\\x(\d\d)", HexToStringMatchEvaluator);
    byte[] bytes = Encoding.ASCII.GetBytes(source);
