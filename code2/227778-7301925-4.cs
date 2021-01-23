    var ts = new TypeSwitch()
        .Case((int x) => Console.WriteLine("int"))
        .Case((bool x) => Console.WriteLine("bool"))
        .Case((string x) => Console.WriteLine("string"));
    ts.Switch(42);
    ts.Switch(false);
    ts.Switch("hello");
