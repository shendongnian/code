    private static void Main(string[] args)
        {
            Console.WriteLine("Press any key to Start Timer");
            Console.ReadKey();
            Console.WriteLine("\nTimer Started");
            var startTime = DateTime.Now;
            Console.WriteLine("Press any key to Stop Timer");
            Console.ReadKey();
            var stopTime = DateTime.Now;
            var sb = "\n" + (stopTime - startTime);
            Console.WriteLine(sb);
        }
