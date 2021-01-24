    string testInput = 
      "1. test 5. wrong 2. It's Correct 3. OK 4. 1. 2. 3. - all wrong 5. Corect Now;";
    string[] report = ParseList(testInput)
      .Select(line => line.Trim())
      .ToArray();
    Console.Write(string.Join((Environment.NewLine, report));
