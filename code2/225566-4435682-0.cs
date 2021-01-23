    private static void ParseIt(string subject)
    {
      Console.WriteLine("subject : {0}\n", subject);
      Regex openers = new Regex(@"[[{(]");
      Regex closers = new Regex(@"[]})]");
      Regex ops = new Regex(@"[*+/-]");
      Regex VariableOrConstant = new Regex(@"((\d+(\.\d+)?)|\w+)" + ops + "?");
      Regex splitter = new Regex(
        openers + @"(?<FIRST>" + VariableOrConstant + @")+" + closers + ops + @"?" +
        @"|" +
        @"(?<SECOND>" + VariableOrConstant + @")" + ops + @"?",
        RegexOptions.ExplicitCapture
      );
      foreach (Match m in splitter.Matches(subject))
      {
        foreach (string s in splitter.GetGroupNames())
        {
          Console.WriteLine("group {0,-8}: {1}", s, m.Groups[s]);
        }
        Console.WriteLine();
      }
    }
