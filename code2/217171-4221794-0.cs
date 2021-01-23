    var dict = new Dictionary<int, string>();
    dict.Add(42, "foo");
    Console.WriteLine(dict[42]);
    dict[42] = "bar";  // overwrite
    Console.WriteLine(dict[42]);
    dict[1] = "hello";  // new
    Console.WriteLine(dict[1]);
    dict.Add(42, "testing123"); // exception, already exists!
