      using System.Linq; // For test only 
      using System.Text.RegularExpressions;
      ...
      Func<string, string> toCamel = (source) =>
        Regex.Replace(source, @"\b\p{Lu}", m => m.Value.ToLower());
      string[] tests = new string[] {
        @"profile.Business.AddressLine1",
        @"MyFunction(Value, SomeId);",
      };
      string report = string.Join(Environment.NewLine, tests
        .Select(test => $"{test,-40} => {toCamel(test)}"));
      Console.WriteLine(report);
