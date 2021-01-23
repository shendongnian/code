    while(!streamReader.EndOfStream)
    {
        string line = streamReader.ReadLine();
        Console.WriteLine(line);
    }
    Console.WriteLine("End of File");
