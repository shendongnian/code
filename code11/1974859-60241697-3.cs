    const int x = -9; //unknown number
    int[] mainArray = new int[] { 3, 1, 0, 1 };
    int[][] inputs = new[]{ //        is match, shift
            new int[] { x, x, x, x }, // true    0
            new int[] { x, x, 1, x }, // true    1
            new int[] { x, x, 1, 0 }, // true    1
            new int[] { x, x, 1, 0 }, // true    1
            new int[] { x, 3, 1, 0 }, // true    1
            new int[] { 1, 3, 1, 0 }, // true    1
            new int[] { 3, 1, 0, x }, // true    0
            new int[] { 3, 1, 1, 0 }, // false
            new int[] { x, 1, 1, x }, // false
            new int[] { 0, 1, 1, x }, // false
            new int[] { 3, 1, x, x },  // true   1           
            //-------- all possible shifts:
            new int[] { 3, 1, 0, 1 },  // true   0 <=> -4          
            new int[] { 1, 3, 1, 0 },  // true   1 <=> -3          
            new int[] { 0, 1, 3, 1 },  // true   2 <=> -2          
            new int[] { 1, 0, 1, 3 },  // true   3 <=> -1            
    };
    const int digits = 3;
    string format = new String('0', digits);
    string inputAsString =
        String.Join(",", mainArray.Select(i => i.ToString(format))) + ",";
    inputAsString = "," + inputAsString + inputAsString;
    Console.WriteLine($"inputAsString = \"{inputAsString}\"");
    foreach (int[] input in inputs) {
        string pattern =
            "," + String.Join(",", input.Select(i => i == x ? @"\d+" : i.ToString(format))) + ",";
        var match = Regex.Match(inputAsString, pattern);
        int shift = -match.Index / (digits + 1);
        if (shift <= -input.Length / 2) {
            shift += input.Length;
        }
        Console.WriteLine($"match = \"{match.Value}\", success = {match.Success}, index = {match.Index}, shift = {shift}");
    }
