    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                Console.WriteLine("Enter a value to get the ascii value: ");
                int value = Console.Read();
                Console.WriteLine("ASCII value is {0}", value);
                keyinfo = Console.ReadKey();
            }
            while (keyinfo.Key != ConsoleKey.Y);
        }
    }
