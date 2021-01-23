    public List<string> Parse(string input)
    {
        List<string> results = new List<string>();
        bool startSection = true;
        int startIndex = 0;
        foreach (Match m in Regex.Matches(input, @"[^\\]&quote;"))
        {
            if (startSection)
            {
                startSection = false;
                // capture a new section
                startIndex = m.Index;
                
            }
            else
            {
                // next match starts a new section to capture
                startSection = true;
                results.Add(input.Substring(startIndex, m.Index - startIndex + 1));
            }
        }
        return results;
    }
