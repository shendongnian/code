    while (!process.HasExited)
    {
        string d = process.StandardOutput.ReadLine();
        Console.WriteLine("Line = {0}", d);
    }
