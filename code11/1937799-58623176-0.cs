    try
    {
        throw new ArgumentOutOfRangeException();
    }
    catch (Exception)
    {
        Console.WriteLine("Caught 'Exception'");
    }
    // This gives a compile error:
    // "Error CS0160  A previous catch clause already catches all exceptions of this or of a super type ('Exception')"
    catch (SystemException)
    {
        Console.WriteLine("Caught 'SystemException'");
    }
