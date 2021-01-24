        public static int GetSum(int a, int b)
        {
            int result = 0;
            int lowerBound = 0;
            int upperBound = 0;
            if (a == b)
            {
                //they are the same so it doesnt matter which one we return
                return a;
            }
            if (a < b)
            {
                lowerBound = a;
                upperBound = b;
            }
            else if (a > b)
            {
                lowerBound = b;
                upperBound = a;
            }
            //loop from lower to upper bound inclusive
            for (int i = lowerBound; i <= upperBound; i++)
            {
                result += i;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetSum(5, -7));
            Console.ReadLine();
        }
