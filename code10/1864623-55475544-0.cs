    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            List<string> arguments = new List<string>();
            do
            {
                Console.WriteLine("Input argument and press <ENTER>: ");
                string argument = Console.ReadLine();
                if (string.IsNullOrEmpty(argument))
                    break;
                arguments.Add(argument);
            } while (true);
            Console.WriteLine("continue...");
        }
        else if (args.Length % 2 == 0)
        {
            //do something else
        }
    }
