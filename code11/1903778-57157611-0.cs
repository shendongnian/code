    static void Main()
    {
        Console.WriteLine("Press any key to start");
        Console.ReadKey();
        do
        {
            // Program.Generator();
            Console.WriteLine("Are you satisfied? Type '1' if yes or '2' if no.");
        } while (Console.ReadKey().KeyChar != '1');
    }
