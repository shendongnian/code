        static void Main(string[] args)
        {
            int total=0,sum=0,parts=3;
            int[] array = { 10, 8, 8, 7, 6, 6, 6, 5 };
            foreach (int i in array)
            {
                total += i;
            }
            int threshold = (total / parts)-(total / array.Length) / 2;
            for (int j = array.Length - 1; j > -1; j--)
            {
                sum += array[j];
                if (sum >= threshold)
                {
                    parts -= 1;
                    Console.WriteLine(sum);
                    sum = 0;
                    continue;
                }
            }
            if (parts > 0)
            {
                Console.WriteLine(sum);
            }
            Console.Read();
        }
