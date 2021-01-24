    try
    {
        throw new ArgumentOutOfRangeException();
    }
    catch (Exception ex)
    {
        if (ex is Exception)
        {
            Console.WriteLine("Caught 'Exception'");
        }
        else if (ex is SystemException) // This will never be reached, but no compile error.
        {
            Console.WriteLine("Caught 'SystemException'");
        }
    }
