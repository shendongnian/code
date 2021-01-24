    public List<string> SplitInSegments(string word, int segments)
    {
        int wordLength = word.Length;
    
        // The remainder tells us how many segments will get an extra letter
        int remainder = wordLength % segments;
    
        // The base length of a segment
        int segmentLength = wordLength / segments;
    
        var result = new List<string>();
        for (int i = 0; i < segments; i++)
        {
            // This segment may get an extra letter, if its index is smaller then the remainder
            int currentSegmentLength = segmentLength + (i < remainder ? 1 : 0);
    
            // The amount of already processed letters
            int startIndex = Math.Min(i, remainder) + (i * segmentLength);
            string currentSegment = word.Substring(startIndex, currentSegmentLength);
    
            result.Add(currentSegment);
        }
    
        return result;
    }
