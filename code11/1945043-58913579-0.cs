    string[] lines = "word longerword longestword evenlongerword aditionalword\nlongerword word evenlongerword longestword".Split('\n');
    string result;
    Dictionary<int, int> wordSize = new Dictionary<int, int>();
    // Build word sizes first
    foreach (string line in lines)
    {
        string[] words = line.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (!wordSize.ContainsKey(i))
                wordSize.Add(i, 0);
            if (wordSize[i] < words[i].Length)
                wordSize[i] = words[i].Length;
        }
    }
    // Output results
    result = string.Empty;
    foreach (string line in lines)
    {
        string[] words = line.Split(' ');
        for (int i = 0; i < words.Length; i++)
            result += words[i].PadRight(wordSize[i] + 1, ' ');
        result = result.TrimEnd();
        result += "\n";
    }
    Console.WriteLine(result);
