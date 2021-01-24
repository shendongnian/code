     private static void Main(string[] args)
        {
            // PrintSeries(7, 13);
            PrintSeries(14, 19);
            Console.WriteLine("=" + sum);
            System.Console.ReadKey();
        }
        private static int sum = 0;
        private static int PrintSeries(int number, int number2)
        {
            if (number <= 1)
            {
                return 0;
            }
            else if (number2 <= number)
            {
                if (number % 2 == 0)
                {
                    return number;
                }
                return number + number % 2;
            }
            else
            {
                int num = PrintSeries(number, number2 - 2);
                Console.Write("+" + num);
                sum += num;
                return num += 2;
            }
        }
