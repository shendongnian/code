    public static void Main()
    {
        var directory = new Dictionary<string, string>();
    
        // Keep requesting inputs
        while (true)
        {
            string input = Console.ReadLine();
            // provide a possibility to break the loop.
            if (input == "exit")
            {
                break;
            }
    
            string[] items = input.Split(' ');
            if (items.Length != 2)
            {
                Console.WriteLine("Expecting '{Name} {Phonenumber}'");
                continue;
            }
    
            directory[items[0]] = items[1];
        }
        // TODO: Do something with directory
    }
