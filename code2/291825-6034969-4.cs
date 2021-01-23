    MyClass y = new MyClass();
    y.Points = 42; // works
    y.Level = 99; // doesn't work
    IMyInterface z = y;
    z.Level = 99; // works
    Console.WriteLine(y.Points); // prints "99"
