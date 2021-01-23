    try
    {
        if (number == 5)
            throw new InvalidNumberException();
    }
    catch (InvalidNumberException e)
    {
       System.Console.WriteLine("Hey I got an InvalidNumberException");
    }
