    var realConsoleStream = Console.Out;
    using (var fileOut = new StreamWriter(outFileName, false))
    {
        Console.SetOut(new TeeTextWriter(fileOut, realConsoleStream));
        try
        {
            Console.WriteLine("Test");
        }
        finally
        {
            Console.SetOut(realConsoleStream);
        }
    }
