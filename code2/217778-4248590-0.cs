    var list = new List<string>
    {
        "A.B.D", "A", "E", "A.B", "F", "F.E", "B.C.D", "B.C"
    };
    var result = from item in list
                 group item by item[0] into g
                 select CommonPrefix(g);
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
