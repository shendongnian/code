    public List<string> SplitInSegments(string word, int segments)
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
