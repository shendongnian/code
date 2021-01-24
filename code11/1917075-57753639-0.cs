    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Select(x => {
                if(int.TryParse(x.ToString(), out int result))
                {
                    return result;
                }
                else
                {
                    return -1;
                }
            }).Where(x => x != -1).ToArray();
            int even = 0;
            int odd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    even = even + numbers[i];
                }
                else
                {
                    odd = odd + numbers[i];
                }
            }
            Console.WriteLine(even * odd);
        }
    }
