    using System.Linq;
    using System.Text.RegularExpressions;
    public static string Decode(string morseCode) {
      string[] words = Regex.Matches(morseCode, @"(?<=^|\s).+?(?=$|\s)")
        .Cast<Match>()
        .Select(match => match.Value.All(c => char.IsWhiteSpace(c)) 
           ? match.Value 
           : match.Value.Trim())
        .ToArray();
      //Relevant code here
    }
