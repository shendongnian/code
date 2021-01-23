    List<Rectangle> l = new List<Rectangle>();
    l.Add(new Rectangle(1, 2, 3, 4));
    l.Add(new Rectangle(1, 2, 3, 4));
    l.Add(new Rectangle(10, 20, 30, 40));
    var grouped = l
        .GroupBy(item => item)
        .Select(group => new Tuple<Rectangle, int>(group.Key, group.Count()));
    foreach (var t in grouped)
    {
        Console.WriteLine("There are {0} rectangles like {1}.", t.Item2, t.Item1);
    }
