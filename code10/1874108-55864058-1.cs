    Box b;
    int id = b.Id; // Compiler will tell you that this is illegal, because "b" is "null".
    Box b = null; // initialize variable with null
    try
    {
        int id = b.Id; // Compiler won't notice that this is empty. An exception will be trown
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex);
    }
