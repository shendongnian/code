      using System.Text.RegularExpressions;
      ...
      // Extracts all capital letters from each word
      Func<string, string> abbreviation = (value) => string.Concat(Regex
        .Matches(value, @"\b\p{Lu}")
        .Cast<Match>()
        .Select(match => match.Value));
      Dictionary<string, string> dict = ListaClientes
        .GroupBy(item => abbreviation(item), StringComparer.OrdinalIgnoreCase)
        .ToDictionary(group => group.Key,
                      group => group.First(), // In case of conflict, use 1st text
                      StringComparer.OrdinalIgnoreCase);
