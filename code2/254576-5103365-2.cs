        var dict = new Dictionary<char, int>();
        string s = "This is a test, with multiple characters";
        foreach (var c in s)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                dict[c] = 1;
            }
        }
        foreach (var k in dict.Keys)
        {
            Console.WriteLine("{0}: {1}", k, dict[k]);
        }
