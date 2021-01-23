        string s = "A string is a data type used in programming, such as an integer and floating point unit, but is used to represent text rather than numbers. It is comprised of a set of characters that can also contain spaces and numbers.";
        List<string> strings = new List<string>();
        int len = 50;
        for (int i = 0; i < s.Length; i += 50)
        {
            if (i + 50 > s.Length)
            {
                len = s.Length - i;
            }
            strings.Add(s.Substring(i,len));
        }
