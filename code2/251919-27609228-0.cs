        public static void print(int no)
        {
            for (int i = 1; i <= no; i++)
            {
                for (int j = i; j <= no; j++)
                {
                    Console.Write("  ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*" + " ");
                } Console.WriteLine();
            } Console.ReadLine();
        }
