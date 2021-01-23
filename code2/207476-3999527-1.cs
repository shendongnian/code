    int foo;
    try
    {
        foo = 2;
    }
    catch (Exception)
    {
        Console.WriteLine(foo); // Use of unassigned local variable 'foo'
    }
