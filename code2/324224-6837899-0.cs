    static void Main(string[] args)
    {
        string input =
            "TEXT  TEXT-1     227.905  174.994  180  1111\n" +
            "TEXT  DIFTEXT    227.905  203.244  180  9999\n" +
            "TEXT  DIFTEXT2   242.210  181.294  180  2222\n" +
            "TEXT  TEXT-2     236.135  198.644  90   ABC1111\n" +
            "TEXT  SOMETEXT   250.610  201.594  0    DDDD\n" +
            "TEXT  OTHERTEXT  269.665  179.894  180  4444\n" +
            "TEXT  OTHERTEXT  269.665  198.144  180  1111";
        string[] lines = input.Split('\n');
        string[][] grid = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries); // split on whitespace
        }
        IEnumerable<string[]> results = grid
            .OrderBy(gridRow => TransformColumn6(gridRow[5]))
            .ThenBy(gridRow => gridRow[1]);
        foreach (string[] gridRow in results)
        {
            Debug.WriteLine(string.Join(" ", gridRow));
        }
    }
    private static string TransformColumn6(string input)
    {
        if (char.IsDigit(input[0]))
        {
            // string is a bunch of numbers, use as-is.
            return input;
        }
        int digitIndex = input.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        if (digitIndex == -1)
        {
            // string has no numbers, use as-is, will be sorted in alphabetical order after all the numbers.
            return input;
        }
        // string has a number, remove the stuff at the beginning.
        return input.Substring(digitIndex);
    }
