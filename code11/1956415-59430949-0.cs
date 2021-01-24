                if (Console.KeyAvailable)
                {
                    keyinfo = Console.ReadKey(true);
                    Console.WriteLine(keyinfo);
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    j--;
                }
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    j++;
                }
                if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    k--;
                }
                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    k++;
                }
              
