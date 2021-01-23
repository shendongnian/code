            static void Main(string[] args)
            {
    #if DEBUG
                args = new[] { "A" };
    #endif
                Console.WriteLine(args[0]);
            }
