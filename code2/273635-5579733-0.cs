    try
    {
         DoSomething();
    }
    catch (NotSupportedException)
    {
         Console.Error.WriteLine("The software won't do what you wanted it to");
    }
    catch (InvalidOperationException)
    {
         Console.Error.WriteLine("A possible programming error in the software?");
    }
