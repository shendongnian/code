                // was a key pressed?
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            m.MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            m.MoveDown();
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                    }
                }
