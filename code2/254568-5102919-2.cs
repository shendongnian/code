    void Main()
    {
        string s = "This is a test, with multiple characters";
        var occurances = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (occurances.ContainsKey(c))
                occurances[c] = occurances[c] + 1;
            else
                occurances[c] = 1;
        }
        foreach (var entry in occurances)
        {
            Debug.WriteLine("{0}: {1}", entry.Key, entry.Value);
        }
    }
