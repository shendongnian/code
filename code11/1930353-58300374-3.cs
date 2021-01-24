    var list = new List<Product>();
    var subject = new Subject<Product>();
    using (var o = subject.Subscribe(i => list.Add(i)))
    {
        subject.OnNext(productSample1);
        subject.OnNext(productSample2);
    }
    
    foreach (var i in list)
    {
        Console.WriteLine(i);
    }
    
    // 1
    // 10
