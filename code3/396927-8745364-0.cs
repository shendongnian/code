    var coll = new Dictionary<Tuple<int,int>, AnyClass>();
    coll.Add(new Tuple<int,int>(2, 3), new AnyClass("foo"));
    coll.Add(new Tuple<int,int>(4, 2), new AnyClass("bar"));
    
    var foo = coll[new Tuple<int,int>(2,3)]; // Foo
    var bar= coll[new Tuple<int,int>(4,2)]; // Bar
