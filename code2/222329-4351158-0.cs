    var t1 = Task.Factory.StartNew<int>(() => 42);
    var t2a = t1.ContinueWith<int>(t => t.Result + 1);
    var t2b = t1.ContinueWith<int>(t => t.Result + 1);
    var t3a = t2a.ContinueWith<int>(t => t.Result * 2);
    var t3b = t2b.ContinueWith<int>(t => t.Result * 3);
    var t4 = TaskEx.WhenAll<int>(t3a, t3b)
                   .ContinueWith<int>(t => t.Result[0] + t.Result[1]);
    t4.ContinueWith(t => { Console.WriteLine(t.Result); });
    Console.ReadKey();
