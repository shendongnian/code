    Regex r = new Regex(@"\d+");
    IList<string> test2 = new List<string>();
    foreach(var item in test)
    {
        Match match = r.match(item);
        test2.Add(match[0]);
    }
    Sort(test2);
