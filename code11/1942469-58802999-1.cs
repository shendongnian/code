            int i, j;
            i = 1;
            int sum = 0;
            while (i < 9)
            {
                int current = 0;
                for (j = 1; j <= i; j += 2)
                {
                    current = 10 * current + i;
                    Console.Write(i);
                }
                Console.Write("\n");
                sum += current;
                i++;
            }
            Console.WriteLine("Summary: " + sum);
            Console.ReadLine();
