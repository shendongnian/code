    // sequences to split on first
    static readonly string[] splitSequences = {
        "el",
        "ol",
        "bo"
    };
    
    static readonly string regexDelimiters = string.Join('|', splitSequences.Select(s => "(" + s + ")"));
    
    // Method to split on sequences
    public static List<string> SplitOnSequences(string word)
    {
        return Regex.Split(word, regexDelimiters).Where(s => !string.IsNullOrEmpty(s)).ToList();
    }
    
    public static List<string> SplitInSegments(string word, int segments)
    {
        int wordLength = word.Length;
    
        // The remainder tells us how many segments will get an extra letter
        int remainder = wordLength % segments;
    
        // The base length of a segment
        // This is a floor division, because we're dividing ints.
        // So 5 / 3 = 1
        int segmentLength = wordLength / segments;
    
        var result = new List<string>();
        int startIndex = 0;
        for (int i = 0; i < segments; i++)
        {
            // This segment may get an extra letter, if its index is smaller then the remainder
            int currentSegmentLength = segmentLength + (i < remainder ? 1 : 0);
    
            string currentSegment = word.Substring(startIndex, currentSegmentLength);
    
            // Set the startindex for the next segment.
            startIndex += currentSegmentLength;
    
            result.Add(currentSegment);
        }
    
        return result;
    }
    
    // Splitword will now always return 3 segments
    public static List<string> SplitWord(string word)
    {
        if (word == null)
        {
            throw new ArgumentNullException(nameof(word));
        }
    
        if (word.Length < 3)
        {
            throw new ArgumentException("Word must be at least 3 characters long", nameof(word));
        }
    
        var splitted = SplitOnSequences(word);
    
        var result = new List<string>();
        if (splitted.Count == 1)
        {
            // If the result is not splitted, just split it evenly.
            result = SplitInSegments(word, 3);
        }
        else if (splitted.Count == 2)
        {
            // If we've got 2 segments, split the shortest segment again.
            if (splitted[1].Length > splitted[0].Length
                && !splitSequences.Contains(splitted[1]))
            {
                result.Add(splitted[0]);
                result.AddRange(SplitInSegments(splitted[1], 2));
            }
            else
            {
                result.AddRange(SplitInSegments(splitted[0], 2));
                result.Add(splitted[1]);
            }
        }
        else // splitted.Count >= 3
        { 
            // 3 segments is good.
            result = splitted;
            // More than 3 segments, combine some together.
            while (result.Count > 3)
            {
                // Find the shortest combination of two segments
                int shortestComboCount = int.MaxValue;
                int shortestComboIndex = 0;
                for (int i = 0; i < result.Count - 1; i++)
                {
                    int currentComboCount = result[i].Length + result[i + 1].Length;
                    if (currentComboCount < shortestComboCount)
                    {
                        shortestComboCount = currentComboCount;
                        shortestComboIndex = i;
                    }
                }
    
                // Combine the shortest segments and replace in the result.
                string combo = result[shortestComboIndex] + result[shortestComboIndex + 1];
                result.RemoveAt(shortestComboIndex + 1);
                result[shortestComboIndex] = combo;
            }
        }
    
        return result;
    }
