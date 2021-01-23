        var r = new Dictionary<string, Point>();
        r.Add("c3", new Point(0, 0));
        r.Add("c1", new Point(0, 0));
        r.Add("t3", new Point(0, 0));
        r.Add("c4", new Point(0, 0));
        r.Add("c2", new Point(0, 0));
        r.Add("t1", new Point(0, 0));
        r.Add("t2", new Point(0, 0));
        var l = r.OrderBy(key => key.Key);
        var dic = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
        foreach (var item in dic)
        {
           
            Console.WriteLine(item.Key);
        }
        Console.ReadLine();
