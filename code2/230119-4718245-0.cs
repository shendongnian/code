    using System.Text.RegularExpressions;
    
    //  A description of the regular expression:
    //  
    //  [Protocol]: A named capture group. [\w+]
    //      Alphanumeric, one or more repetitions
    //  :\/\/
    //      :
    //      Literal /
    //      Literal /
    //  [Domain]: A named capture group. [[\w@][\w.:@]+]
    //      [\w@][\w.:@]+
    //          Any character in this class: [\w@]
    //          Any character in this class: [\w.:@], one or more repetitions
    //  Literal /, zero or one repetitions
    //  Any character in this class: [\w\.?=%&=\-@/$,], any number of repetitions
    
    public Regex MyRegex = new Regex(
          "(?<Protocol>\\w+):\\/\\/(?<Domain>[\\w@][\\w.:@]+)\\/?[\\w\\."+
          "?=%&=\\-@/$,]*",
        RegexOptions.IgnoreCase
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
    
    
    // Replace the matched text in the InputText using the replacement pattern
     string result = MyRegex.Replace(InputText,MyRegexReplace);
    
    // Split the InputText wherever the regex matches
     string[] results = MyRegex.Split(InputText);
    
    // Capture the first Match, if any, in the InputText
     Match m = MyRegex.Match(InputText);
    
    // Capture all Matches in the InputText
     MatchCollection ms = MyRegex.Matches(InputText);
    
    // Test to see if there is a match in the InputText
     bool IsMatch = MyRegex.IsMatch(InputText);
    
    // Get the names of all the named and numbered capture groups
     string[] GroupNames = MyRegex.GetGroupNames();
    
    // Get the numbers of all the named and numbered capture groups
     int[] GroupNumbers = MyRegex.GetGroupNumbers();
