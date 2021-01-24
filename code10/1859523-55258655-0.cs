      string source = string.Join(Environment.NewLine, 
        "Line1",
        "Line2", 
        "Line3");
      // Let's have a look at the initial string; 
      Console.WriteLine(source);
      Console.WriteLine();
      string result = string.Join(Environment.NewLine, source
        .Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
        .Select(line => line + "AppendedText"));
      Console.Write(result);
