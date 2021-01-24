    using System.Linq;
    ...
    public static string ToLiteral(string input) =>
      string.IsNullOrEmpty(input)
        ? input
        : string.Concat(input.Select(c => char.IsControl(c) 
            ? $"\\u{((int)c):x4}" 
            : c.ToString()));
