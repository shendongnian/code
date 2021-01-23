    class Program
    {
        static void Main(string[] args)
        {
            Method1(null);
            Method2(null);
        }
        static void Method1(object sender)
        {
            if (sender == null)
                return;
            for (int x = 0; x < 100; x++)
            {
                Console.WriteLine(x.ToString());
            }
        }
        static void Method2(object sender)
        {
            if (sender != null)
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.WriteLine(x.ToString());
                }
            }
        }
    }
