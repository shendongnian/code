        private static void WriteStars(int width, int height)
        {
            int j = 0;
            for (int i = 0; i < height; i++)
            {
                Console.Write("|");
                for (int f = 0; f < width; f++)
                {
                    if (f == Math.Abs(j))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                j++;
                if (Math.Abs(j) == width - 1)
                {
                    j *= -1;
                }
                Console.WriteLine("|");
            }
        }
