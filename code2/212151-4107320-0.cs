        static void Main(string[] args)
        {
            int i = 0;
            try
            {
                i = 1;
                Console.WriteLine(i);
                return;
            }
            finally
            {
                Console.WriteLine("finally.");
            }
        }
