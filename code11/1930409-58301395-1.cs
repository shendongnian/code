    class Program
    {
        static void Main(string[] args)
        {
            int[] indexes = GetSumIndexes(new int[] { 3, 2, 4 }, 6);
        }
        public static int[] GetSumIndexes(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        if (numbers[i] + numbers[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return new int[] { };
        }
    }
