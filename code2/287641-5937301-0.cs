    private static List<string> Split(string input, IEnumerable<string> delimiters)
    {
        List<string> results = new List<string>();
        List<int> indices = new List<int>();
        // get indices of delimiters
        foreach (string s in delimiters)
        {
            int idx = input.IndexOf(s);
            if (idx >= 0)
                indices.Add(idx);
        }
        indices.Sort();
        if (indices.Count > 0)
        {
            indices.Add(input.Length);
            // split the string
            for (int i = 0; i < indices.Count - 1; i++)
            {
                int idx = indices[i], nextIdx = indices[i + 1];
                results.Add(input.Substring(idx, nextIdx - idx).Trim());
            }
        }
        return results;
    }
