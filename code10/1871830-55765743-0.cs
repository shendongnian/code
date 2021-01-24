        static void Main(string[] args)
        {
            char STAR = '*';
            char DOT = '.';
            var input = new char[,]
            {
                { STAR,STAR,STAR,STAR,STAR},
                { STAR,STAR,DOT,STAR,STAR},
                { STAR,STAR,STAR,STAR,STAR},
                { STAR,STAR,STAR,STAR,DOT}
            };
            var output = new char[4, 5];
            // Copy each from input to output, checking if it touches a '.'
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 5; y ++)
                {
                    if (input[x, y] == STAR)
                    {
                        var isDot = false;
                        // Check left
                        if (x > 0)
                            isDot = input[x - 1, y] == DOT;
                        // Check right
                        if (x < 3)
                            isDot = isDot || (input[x + 1, y] == DOT);
                        // Check above
                        if (y > 0)
                            isDot = isDot || (input[x, y - 1] == DOT);
                        // Check below
                        if (y < 4)
                            isDot = isDot || (input[x, y + 1]) == DOT;
                        output[x, y] = isDot ? DOT : STAR;
                    }
                    else
                    {
                        output[x, y] = input[x, y];
                    }
                }
            }
            // Print output
            for (int x = 0; x < 4; x ++)
            {
                for (int y = 0; y < 5; y ++)
                {
                    Console.Write(output[x, y]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
