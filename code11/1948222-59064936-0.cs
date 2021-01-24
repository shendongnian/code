    using System.Linq;
    using System.Text.RegularExpressions;
    ...
    string source =
      @"This is example 1, this is example 2, that is example 3";
    string word = "is";
            
    string[] result = Regex
      .Matches(source, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)
      .Cast<Match>()
      .Select(match => 
         $"{source.Substring(0, match.Index)}###{source.Substring(match.Index + match.Length)}")
      .ToArray();
