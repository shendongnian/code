    var listA = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var listB = new List<string> { "A", "B", "C", "D" };
    var listC = new List<string> { "!", "?", "-" };
    var result = Enumerable.Range(0, Math.Max(Math.Max(listA.Count, listB.Count), listC.Count))
        .Select(i => new
        {
            a = listA.ElementAtOrDefault(i),
            b = listB.ElementAtOrDefault(i),
            c = listC.ElementAtOrDefault(i)
        }).ToList();
    foreach (var item in result)
    {
        Console.WriteLine("{0} {1} {2}", item.a, item.b, item.c);
    }
