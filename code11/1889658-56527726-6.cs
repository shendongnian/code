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
        "a_b_c=d_e_f",
      };
      string report = string.Join(Environment.NewLine, tests
        .Select(test => string.Join("; ", Regex.Split(test, "[><=]+"))));
      Console.Write(report);
