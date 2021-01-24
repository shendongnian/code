    static void Main(string[] args)
        {
            Console.WriteLine("Enter the array Size:\t");
            int n = GetIntFromInput();
            if (n <= 0)
            {
                Console.WriteLine("Array has to be at least of size 1...");
                return;
            }
            Console.WriteLine("Enter the array elements of {0} as Array Size:\n", n);
            var arrSum = new int[n];
            for (int i = 0; i < n; i++)
            {
                int newInt = GetIntFromInput();
                arrSum[i] = newInt;
            }
            Console.WriteLine("Enter the number whose sum you want to find:\n");
            int j = Convert.ToInt32(Console.ReadLine());
            ArraySum(arrSum, n, j);
        }
