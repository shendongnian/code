    static void Main()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            int i;
            if (int.TryParse(key.KeyChar.ToString(), out i))
            {
                Console.Write(key.KeyChar);
            }
        }
    }
