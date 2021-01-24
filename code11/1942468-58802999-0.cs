            int i, j;
            i = 1;
            int sum = 0;
            while (i < 9)
            {
                string str = string.Empty;
                for (j = 1; j <= i; j += 2)
                {
                    str += i;
                    Console.Write(i);
                }
                Console.Write("\n");
                sum += Convert.ToInt32(str);
                i++;
            }
            Console.WriteLine("Summary: " + sum);
            Console.ReadLine();
