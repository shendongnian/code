     string testInput = "1. Mr Test Test 2. £100,000 3. 5 Test Road";
     string[] lines = ParseListToLines(testInput).ToArray();
     // string Name = lines[0].Trim();
     // string Money = lines[1].Trim();
     // string Address = lines[2].Trim();
     Console.Write(string.Join(Environment.NewLine, lines));
