    var list = new List<int>();
    var subject = new Subject<int>();
    using (var o = subject.Subscribe(i => list.Add(i)))
    {
        subject.OnNext(1);
        subject.OnNext(10);
    }
    
    foreach (var i in list)
    {
        Console.WriteLine(i);
    }
    
    // 1
    // 10
