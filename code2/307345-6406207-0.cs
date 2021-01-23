    var list = new List<String>();
    for (int i = 0; i < 7; i++) list.Add("Widget #" + (i + 1));
    var groupedWidgets = list
        .Select((w, i) => new { Widget = w, Index = i })
        .GroupBy(x => (int)(x.Index / 2));
    foreach (var g in groupedWidgets)
    {
        Console.WriteLine("<div>");
        foreach (var w in g)
        {
            Console.WriteLine("  " + w.Widget);
        }
        Console.WriteLine("</div>");
    }
