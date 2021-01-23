    class Program
    {
        public static void Main()
        {
            var hey = new int[][]
            {
                new int[]{11, 12, 13},
                new int[]{21, 22, 23},
                new int[]{31, 32, 33},
            };
    
            foreach (var row in hey)
            {
                foreach (int i in row)
                {
                    Console.Write("{0} ", i);
                }
    
                Console.WriteLine();
            }
    
            Console.ReadLine();
        }
    }
