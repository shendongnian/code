    try
    {
        if (totalSum < 0)
            throw new ApplicationException();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Total sum is too small");
        Environment.Exit(1);
    }
