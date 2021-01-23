            int i = 0;
            while (i < num.Length)
            {
                for (int j = i; j < num.Length;j++)
                {
                    if((j+1)<num.Length)
                    num[i] = num[i] + num[j + 1];
                }
                Console.WriteLine(num[i]);
                i++;
            }
