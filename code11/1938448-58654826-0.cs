    static void Main(string[] args)
            {
                KeyDetect();
                Console.ReadKey();
            }
    
            public static void KeyDetect()
            {
                ConsoleKey key;
                key = Console.ReadKey(true).Key;
                if (key==ConsoleKey.A)
                {
                    Console.WriteLine("You are pressing A");
                }
            }
