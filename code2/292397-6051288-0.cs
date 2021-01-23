        static void Main(string[] args)
        {
            string value = Console.Read().ToString();
            Console.WriteLine("You entered: {0}", value);
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();   // Returns immediately.
            Console.WriteLine("Continuing....");
        }
