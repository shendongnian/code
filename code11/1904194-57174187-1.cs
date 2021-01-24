    static void Main(string[] args)
    {
        if (args.Length == 0 )
        {
            Console.WriteLine("Command line Usage: ConsoleAppName.exe filePath");
            Console.WriteLine("You can drag and drop files into the executable to use it");
            // Optional: take a path from Console.ReadLine
        }
        else
        {
            foreach (var filePath in args)
            {
                Console.WriteLine($"Processing: {filePath}");
                // Optional: check if folder and handle correctly
                ProcessFile(filePath);
            }
            Console.WriteLine("All done");
        }
        Console.WriteLine("[Press any key to exit]");
        Console.ReadKey();
    }
