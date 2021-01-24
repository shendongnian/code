      string[] tests = new string[] {
        "C=A+B",
        "D= C+50",
        "E = (A+B)*C -100",
      };
      string result = string.Join(Environment.NewLine, tests
        .Select(test => new {
          formula = test,
          parsed = Parse(test)
            .SkipWhile(term => term != "=") // we don't want "C = " or alike part
            .Skip(1)
        })
        .Select(test => $"{test.formula,-20} => {string.Join(", ", test.parsed)}"));
     Console.Write(result);
