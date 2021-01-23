    static void Main(string[] args)
    {
        StreamWriter writer = File.CreateText("process.lst");
        Console.WriteLine("Writing to the file.");
        writer.Write("Testing 1.2.3.4");
        Console.WriteLine("Finished.");
    }
