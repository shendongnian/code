    class Myclass
    {
        int i, n, j;
        public void getData()
        {
            Console.WriteLine("Program for displaying pattern of *.");
            Console.Write("Enter the maximum number of *: ");
            this.n = Convert.ToInt32(Console.ReadLine());
            // OR
            //n = Convert.ToInt32(Console.ReadLine());
        }
        public void pattern()
        {
            Console.WriteLine("\nPattern 1 - Left Aligned:\n");
            for (i = 1; i <= n; i++)  // The Control does not enter the for loop
            {
                for (j = 1; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
