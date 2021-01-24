    public static List<string> GetCombinatins(string input)
    {
        // Sample input = "1[a-C]3[1-6]07[R,E-G]"
        var inputWithPlaceholders = string.Empty;   // This will become "1{0}3{1}07{2}"
        var placeholder = 0;
        var ranges = new List<List<char>>();
        for (int i = 0; i < input.Length; i++)
        {
            // We've found a range start, so replace this with our 
            // placeholder '{n}' and add the range to our list of ranges
            if (input[i] == '[')
            {
                inputWithPlaceholders += $"{{{placeholder++}}}";
                var rangeEndIndex = input.IndexOf("]", i);
                ranges.Add(GetRange(input.Substring(i, rangeEndIndex - i)));
                i = rangeEndIndex;
            }
            else
            {
                inputWithPlaceholders += input[i];
            }
        }
        if (ranges.Count == 0) return new List<string> {input};
        // Add strings for the first range
        var values = ranges.First().Select(chr =>
            inputWithPlaceholders.Replace("{0}", chr.ToString())).ToList();
        // Then continually add all combinations of other ranges
        for (int i = 1; i < ranges.Count; i++)
        {
            values = values.SelectMany(value =>
                ranges[i].Select(chr =>
                    value.Replace($"{{{i}}}", chr.ToString()))).ToList();
        }
        return values;
    }
