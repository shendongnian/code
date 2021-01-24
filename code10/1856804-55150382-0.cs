    string s = "<0,15><1,16><2,17><3,18>";
    string[] delimiters = { "<", ">" };
    List<Tuple<uint, uint>> taglist = new List<Tuple<uint, uint>>();
    string[] res = s.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
    System.Console.WriteLine(res.Length);
    
    foreach (string pairs in res)
    {
        System.Console.WriteLine(pairs);
        string[] delim = { "," };
        string[] pair = pairs.Split(delim, System.StringSplitOptions.RemoveEmptyEntries);
        taglist.Add(new Tuple<uint, uint>(UInt32.Parse(pair[0]), UInt32.Parse(pair[1])));
    }
    
    foreach (Tuple<uint,uint> elem in taglist)
    {
        Console.WriteLine(elem);
    }
