    var list = new[] { "A.B.D", "A", "E", "A.B", "F", "F.E", "B.C.D", "B.C" };
    var result = from s in list
                 group s by s.Split('.').First() into g
                 select LongestCommonPrefix(g);
    foreach (var s in result)
    {
        Console.WriteLine(s);
    }
