      // Let's build multiline string...
      string testInput = string.Join(Environment.NewLine, Enumerable
        .Range(1, 12)
        .Select(i => $"{i}.String #{i}"));
      Console.WriteLine(testInput);
      Console.WriteLine("---");
      // ... and parse it into lines
      string[] lines = ParseList(testInput).Select(line => line.Trim()).ToArray();
      Console.WriteLine(string.Join(Environment.NewLine, lines));
