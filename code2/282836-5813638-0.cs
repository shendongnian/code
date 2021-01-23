    public List<string> ParseWords(string s)
    {
        List<string> words = new List<string>();
        int pos = 0;
        while (pos < s.Length)
        {
            // Get word start
            int start = pos;
            // Get word end
            pos = s.IndexOf('|', pos);
            while (pos > 0 && s[pos - 1] == '\\')
            {
                pos++;
                pos = s.IndexOf('|', pos);
            }
            // Adjust for pipe not found
            if (pos < 0)
                pos = s.Length;
            // Extract this word
            words.Add(s.Substring(start, pos - start));
            // Skip over pipe
            if (pos < s.Length)
                pos++;
        }
        return words;
    }
