      // Let's build multiline string...
      string testInput = string.Join(Environment.NewLine, Enumerable
        .Range(1, 12)
        .Select(i => $"{i,2}.String #{i} {(i < 3 ? "\r\n   Next Line" : "")}"));
      Console.WriteLine("Initial:");
      Console.WriteLine();
      Console.WriteLine(testInput);
      Console.WriteLine();
      Console.WriteLine("Parsed:");
      Console.WriteLine();
      // ... and parse it into lines
      string[] lines = ParseList(testInput)
        .Select(line => line.Trim())
        .Select((item, index) => $"line number {index} = \"{item}\"")
        .ToArray();      
      Console.WriteLine(string.Join(Environment.NewLine, lines));
