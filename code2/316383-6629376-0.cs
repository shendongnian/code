    var input = new StreamReader(File.OpenRead("input.txt"));
    char[] toMatch = ",\"".ToCharArray ();
    string line;
    while (null != (line = input.ReadLine()))
    {
        var result = new StringBuilder(line);
        bool inquotes = false;
        
        for (int index=0; -1 != (index = line.IndexOfAny (toMatch, index)); index++)
        {
            bool isquote = (line[index] == '\"');
            inquotes = inquotes != isquote;
            
            if (!(isquote || inquotes))
                result[index] = '\t';
        }
        Console.WriteLine (result);
    }
