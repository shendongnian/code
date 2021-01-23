    using System.Text.RegularExpressions;
    
    public static Regex regex = new Regex(
          "(\\d|[,\\.])*",
        RegexOptions.IgnoreCase
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
    
    //// Capture the first Match, if any, in the InputText
    Match m = regex.Match(InputText);
    
    //// Capture all Matches in the InputText
    MatchCollection ms = regex.Matches(InputText);
    
    //// Test to see if there is a match in the InputText
    bool IsMatch = regex.IsMatch(InputText);
    
