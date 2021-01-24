            int diag = 9;
            for (int i = 1; i < 10; i++)
            {
                Console.Write($"{i}\t");
                for (int j = 2; j < 10; j++)
                {
                    if (diag != j)
                        Console.Write($"{j * i}\t");
                    else
                        Console.Write($"[{j * i}]\t");
                }
                diag--;
                Console.WriteLine();
            }
