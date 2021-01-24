    static void Main(string[] args)
            {
                int val = 5;
                for (int m = val; m > 0; m--)
                {
                    Console.WriteLine(new string('*', m));
                }
                for (int n = 1; n <= 5; n++)
                {
                    Console.WriteLine(new string('*', n));
                }
                Console.ReadLine();
            }
