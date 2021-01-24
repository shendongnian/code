        static void ConsoleMessage(string message) => Console.WriteLine(message);
        static void ExampleIndirect(string message)
        {
            ConsoleMessage(message);
        }
        
        static void ExampleDirect(string message)
        {
            Console.WriteLine(message);
        }
