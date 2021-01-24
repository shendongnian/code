      using System.Text.RegularExpressions;
      ...
      string[] tests = new string[] {
        "abc",
        "def (123)",
        "pqr (123) def",
        "abs (789) (123)",
      };
      Func<string, string> solution = (line) =>
        Regex.Replace(line, 
          @"\((?<value>[0-9]+)\)$", 
          m => $"({int.Parse(m.Groups["value"].Value) + 1})");
      string demo = string.Join(Environment.NewLine, tests
        .Select(test => $"{test,-20} => {solution(test)}"));
      Console.Write(demo);
