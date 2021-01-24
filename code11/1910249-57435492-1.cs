    public List<string> SplitInSegments(string word, int segments)
    {
        int wordLength = word.Length;
    
        // Calculate the length of the text on each button
        int lettersPerSegment = (wordLength + (wordLength % segments)) / segments;
    
        var result = new List<string>();
        for (int i = 0; i < segments; i++)
        {
            int startIndex = i * lettersPerSegment;
    
            // The last button text may be shorter, account for that.
            int currentLength = Math.Min(wordLength - startIndex, lettersPerSegment);
            string currentSegment = word.Substring(startIndex, currentLength);
    
            result.Add(currentSegment);
        }
    
        return result;
    }
