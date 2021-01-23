    List<object> r = new List<object>();
    r.Add("apple");
    r.Add("John");
    r.Add("orange");
    r.Add("Bob");
    
    var dict = r.Where((o, i) => i % 2 == 0)
        .Zip(r.Where((o, i) => i % 2 != 0), (a, b) => new { Name = a.ToString(), TeacherName = b.ToString() });
    
    foreach (var item in dict)
    {
        Console.WriteLine(item);
    }
