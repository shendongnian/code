      using System.Linq;
      ...
      private static string Encode(string value) {
        if (null == value)
          return null;
        return string.Concat(value
          .Select(c => char.IsControl(c) 
             ? $"\\u{((int) c):x4}"
             : c.ToString()));
      }
