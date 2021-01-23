    Test test = new Test();
    test.Foo = 24;
    Test newTest = test;
    newTest.Foo = 42;
    Console.WriteLine(test.Foo); // Prints 42!
