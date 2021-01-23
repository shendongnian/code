        char[] validChars = Enumerable.Range(0, 26).Select(i => (char)('A' + i)).ToArray();
        int n = 30;
        int pointer = 0;
        string prefix = string.Empty;
        List<string> result = new List<string>();
        while (n > 0)
        {
            result.AddRange(validChars.Skip(pointer).Select(ch => prefix + ch).Take(n));
            prefix += validChars[pointer];
            n = n - validChars.Length + pointer;
            pointer++;
        }
