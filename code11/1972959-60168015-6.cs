    static void Main(string[] args)
    {
        int i = 0;
        while (true)
        {
            Console.ReadKey(false);
            Console.WriteLine($"You are currently at line #{++i}");
            Console.SetWindowPosition(0, i - 1);
        }
    }
