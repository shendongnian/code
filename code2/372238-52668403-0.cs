            int num = 2;
            int[] value = { 1, 2, 3, 4, 5, 6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
            int s = 0;
            int e = value.Length - 1;
            int m = (s + e) / 2;
            bool find = false;
            do
            {
                if (value[m] == num)
                {
                    Console.WriteLine("We have found the given number");
                    find = true;
                }
                else if (num < value[m])
                {
                    e = m - 1;
                }
                else 
                {
                    s = m + 1;
                }
                m = (s + e) / 2;
            } while (find != true);
