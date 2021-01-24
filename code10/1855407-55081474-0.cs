           while (Console.ReadKey(true).Key>0)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    x++;
                    Console.WriteLine(x);
                }
            }
