    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            int sum1 = numbers.Sum();
            int sum2 = GetSum2(numbers);
            int sum3 = GetSum3(numbers);
            int sum4 = GetSum4(numbers);
        }
        private static int GetSum2(List<int> numbers)
        {
            int total = 0;
            foreach (int number in numbers)
            {
                total += number;
            }
            return total;
        }
        private static int GetSum3(List<int> numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                total += numbers[i];
            }
            return total;
        }
        private static int GetSum4(List<int> numbers)
        {
            int total = 0;
            numbers.ForEach((number) =>
            {
                total += number;
            });
            return total;
        }
    }
