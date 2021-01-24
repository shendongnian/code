      using System.Linq;
      using System.Text.RegularExpressions;
      ...
      string source = = ".... . -.--   .--- ..- -.. .";
      string[] words = Regex.Matches(source, @"(?<=^|\s).+?(?=$|\s)")
        .Cast<Match>()
        .Select(match.Value.All(c => char.IsWhiteSpace(c)) 
           ? match.Value 
           : match.Value.Trim())
        .ToArray();
      string report = string.Join(Environment.NewLine, words
        .Select((word, i) => $"words[{i}] = \"{word}\""));
      Console.Write(report);
