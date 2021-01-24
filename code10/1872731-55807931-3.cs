        private static void ConsoleMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static void ExampleDirect(string message)
        {
            Console.WriteLine(message);
        }
        private static void ExampleIndirect(string message)
        {
            Program.ConsoleMessage(message);
        }
