    using System.Linq;
    using System.Text.RegularExpressions;
    ...
    public static int FindShort(string value) {
      if (null == value)
        return 0; // or throw new ArgumentNullException(nameof(value));
      return Regex
        .Matches(value, @"[\p{L}']+")
        .Cast<Match>()
        .Min(match => match.Value.Length);
    }
