        IEnumerable<string> Substrings(string str, int size)
        {
            return Enumerable.Range(0, str.Length - size + 1)
                .Select(i => str.Substring(i, size));
        }
        Console.Write(string.Join(",", Substrings("GCATACGAT", 3).ToList()));
