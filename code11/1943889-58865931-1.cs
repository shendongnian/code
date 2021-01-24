    static void Main(string[] args)
    {
        int cookie = 0;
        Console.WriteLine("Coockie Clicker, druk op spatie om te beginnen...");
        Console.ReadKey();
        Console.Clear();
        while (cookie <1000000)
        {
            var ch = Console.ReadKey(true);
            if(ch.KeyChar == ' ')
            {
                cookie++;
                Console.WriteLine("Cookies ="+cookie);
            }
        }
    }
