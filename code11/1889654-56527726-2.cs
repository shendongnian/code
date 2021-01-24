      string[] tests = new string[] {
        "name>123",
        "name<4",
        "name=78",
        "name==other",
        "name===other",
        "name<>78",
        "name<<=4",
        "name=>name + 455",
        "name>=456",
      };
      string report = string.Join(Environment.NewLine, tests
        .Select(test => string.Join("; ", Regex.Split(test, "[><=]+"))));
      Console.Write(report);
