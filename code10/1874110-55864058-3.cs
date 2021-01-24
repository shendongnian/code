    Box b = null; // initialize variable with null
    try
    {
        int id = b.Id; // Compiler won't notice that this is empty. An exception will be trown
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex);
    }
