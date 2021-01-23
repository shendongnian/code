    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Write("Press a key: ");
                cki = Console.ReadKey(true);
                Console.WriteLine();
                if (cki.Key == ConsoleKey.D1)
                {
                    Console.Write("You pressed: 1");
                }
            }
            while (cki.Key != ConsoleKey.D2);
        } // <-- application terminates here
    }
