    public static void LineDiaglonal(int x, int y, int length, char start, char end, int space = 1)
        {
            for (var i = 0; i < length; i++)
            {
                var X = x + i * space;
                var Y = y + i;
                Console.SetCursorPosition(X, Y);
                if (i == 0)
                {
                    Console.Write(start);
                }
                else if (i == (length - 1))
                {
                    Console.Write(end);
                }
                else
                {
                    Console.Write('└');
                }
                if (space > 0 && i < (length - 1))
                {
                    var x2 = X + 1;
                    for (var s = 0; s < space; s++)
                    {
                        Console.SetCursorPosition(x2 + s, Y);
                        if (s == (space - 1))
                        {
                            Console.Write('┐');
                        }
                        else
                        {
                            Console.Write('─');
                        }
                    }
                }
            }
        }
