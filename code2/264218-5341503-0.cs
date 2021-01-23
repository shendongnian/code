    string text = "One car red car blue car";
    string pat = @"(\w+)\s+(car)";
    // Compile the regular expression.
    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    // Match the regular expression pattern against a text string.
    Match m = r.Match(text);
    int matchCount = 0;
    while (m.Success) 
    {
       Console.WriteLine("Match"+ (++matchCount));
       for (int i = 1; i <= 2; i++) 
       {
          Group g = m.Groups[i];
          Console.WriteLine("Group"+i+"='" + g + "'");
          CaptureCollection cc = g.Captures;
          for (int j = 0; j < cc.Count; j++) 
          {
             Capture c = cc[j];
             System.Console.WriteLine("Capture"+j+"='" + c + "', Position="+c.Index);
          }
       }
       m = m.NextMatch();
    }
