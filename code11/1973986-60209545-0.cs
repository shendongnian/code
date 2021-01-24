    using System.Linq;
    ...
    private static Dictionary<string, string> GetVariables(string source) {
      return source
        .Split(';')
        .Select(pair => pair.Split('='))
        .ToDictionary(pair => pair[0].Trim(), pair => pair[1].Trim());
    }
