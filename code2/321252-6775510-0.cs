    var o = new ReplaySubject<string>();
    var bs = new BehaviorSubject<string>(default(string));
    o.Where(i => i.StartsWith("b")).Subscribe(bs);
    o.OnNext("blueberry"); Console.WriteLine(bs.First());
    o.OnNext("chimpanzee"); Console.WriteLine(bs.First());
    o.OnNext("abacus"); Console.WriteLine(bs.First());
    o.OnNext("banana"); Console.WriteLine(bs.First());
    o.OnNext("apple"); Console.WriteLine(bs.First());
    o.OnNext("cheese"); Console.WriteLine(bs.First());
