    public class ValueChain
    {
      public readonly IEnumerable<object> Values;
      public int ValueCount = 0;
      private static readonly Regex _rx = 
        new Regex("((?<alpha>[a-z]+)|(?<numeric>([0-9]+)))", 
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
      public ValueChain(string valueString)
      {
        Values = Parse(valueString);
      }
      private IEnumerable<object> Parse(string valueString)
      {
        var matches = _rx.Matches(valueString);
        ValueCount = matches.Count;
        foreach (var match in matches.Cast<Match>())
        {
          if (match.Groups["alpha"].Success)
            yield return match.Groups["alpha"].Value;
          else if (match.Groups["numeric"].Success)
            yield return int.Parse(match.Groups["numeric"].Value);
        }
      }
    }
