    static void Main(string[] args)
    {
        int v = 1;
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(v);
            v = v + 1;
            if (i % 5 == 0)
            {
                Console.WriteLine("Done");
            }
        }
    }
