    class Program
    {
        static CommandStrategies CommandHandlers = new CommandStrategies();
        static void Main()
        {
            PrintSupportedCommands();
            while (true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();
                if (command == "exit") return;
                bool isCommandSupported = CommandHandlers.SupportsCommand(command);
                if (!isCommandSupported)
                {
                    Console.WriteLine("Command is not supported.");
                    PrintSupportedCommands();
                }
                else
                {
                    CommandHandlers.ExecuteCommand(command);
                }
            }
        }
        static void PrintSupportedCommands()
        {
            Console.WriteLine("Supported commands are:");
            foreach (var cmd in CommandHandlers.GetSupportedCommands())
            {
                Console.WriteLine(cmd);
            }
            Console.WriteLine("exit");
        }
    }
