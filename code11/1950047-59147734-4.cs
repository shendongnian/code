    public static void PrintLongestLinesAndIndexes(string[] input)
    {
        Console.WriteLine(string.Join(Environment.NewLine,
            input.Select((item, index) => new {item, index})
                .GroupBy(i => i.item.Length)
                .OrderByDescending(i => i.Key)
                .First()
                .Select(line => $"'{line.item}' was found at index: {line.index}")));
    }
