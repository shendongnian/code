    class LineReader
    {
        public static bool Quit;
        public static string ReadLine()
        {
            Quit = false;
            // Wait for input; none is shown as available until a complete line is entered
            while (!Quit && (Console.KeyAvailable == false))
                Thread.Sleep(250);
            if (Quit)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            // This loop should terminate because a complete line (ending in cr/lf) will have been entered
            while (true)
            {
                int c = Console.Read();
                if (c == -1)
                {
                    return sb.ToString();
                }
                else if ((c == 10) || (c == 13))
                {
                    if ((c == 13) && (Console.In.Peek() == 10))
                        Console.In.Read();
                    return sb.ToString();
                }
                else
                {
                    sb.Append((char)c);
                }
            }
        }
    }
