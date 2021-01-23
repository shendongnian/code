        static double ReadNumber()
        {
            var buf = new StringBuilder();
            for (; ; )
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter && buf.Length > 0)
                {
                    Console.WriteLine();
                    return Convert.ToDouble(buf.ToString());
                }
                else if (key.Key == ConsoleKey.Backspace && buf.Length > 0)
                {
                    buf.Remove(buf.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.Contains(key.KeyChar) && buf.ToString().IndexOf(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) == -1)
                {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
                else if ("-".Contains(key.KeyChar) && buf.ToString().IndexOf("-") == -1 && buf.ToString() == "")
                {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
                else if ("0123456789".Contains(key.KeyChar))
                {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
                else
                {
                    Console.Beep();
                }
            }
        }
