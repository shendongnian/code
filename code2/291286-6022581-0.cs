    var s = "['a;b;c','d','e']";
    List<string> list = new List<string>();
    int i = 0;
    while (i < s.Length)
    {
        char c = s[i++];
        if (c == '[')
        {
            while (i < s.Length)
            {
                c = s[i++];
                if (c == '\'')
                {
                    int start = i;
                    while (i < s.Length && s[i] != '\'')
                        i++;
                    list.Add(s.Substring(start, i - start));
                    i++;
                }
                if (i < s.Length && s[i] == ',')
                    i++;
            }
        }
        if (i < s.Length && s[i] == ']')
            i++;
    }
    foreach (var item in list)
        Console.WriteLine(item);
 
