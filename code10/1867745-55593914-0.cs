                Random rand = new Random();
                int[] numbers = new int[4];
                for(int i = 0; i < 4; i++)
                {
                    numbers[i] = rand.Next(1000, 10000);
                }
                Console.WriteLine(string.Join("-", numbers));
                Console.ReadLine();
