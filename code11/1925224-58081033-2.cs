      Func<string, string> convert = (source => {
        int index = 0;
        return Regex.Replace(source, "\"([^\"]|\"\")*\"", m => $"\"{{{++index}}}\"");
      });
      String[] tests = new string[] {
        "abc",
        "\"abc\", \"def\"\"fg\"",
        "\"\"",
        "\"24.09.2019\",\"545\",\"878\",\"5\"",
        "name is \"my name\"; value is \"78\"\"\"\"\"",
        "empty: \"\" and not empty: \"\"\"\""
      };
      string demo = string.Join(Environment.NewLine, tests
        .Select(test => $"{test,-50} -> {convert(test)}"));
      Console.Write(demo);
