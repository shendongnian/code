    public static void PrintLongestLinesAndIndexes(string[] input)
    {
        if (input == null)
        {
            Console.WriteLine("No data");
            return;
        }
        var longestLine = string.Empty;
        var longestLines = new Dictionary<int, string>();
        for (int i = 0; i < input.Length; i++)
        {
            // If this line is longer, reset our variables
            if (input[i].Length > longestLine.Length)
            {
                longestLine = input[i];
                longestLines = new Dictionary<int, string> {{i, input[i]}};
            }
            // If it's the same length, add it to our dictionary
            else if (input[i].Length == longestLine.Length)
            {
                longestLines.Add(i, input[i]);
            }
        }
        foreach (var line in longestLines)
        {
            Console.WriteLine($"'{line.Value}' was found at index: {line.Key}");
        }
    }
