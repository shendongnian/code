        static string ReadNumber() {
            var buf = new StringBuilder();
            for (; ; ) {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter && buf.Length > 0) {
                    return buf.ToString() ;
                }
                else if (key.Key == ConsoleKey.Backspace && buf.Length > 0) {
                    buf.Remove(buf.Length-1, 1);
                    Console.Write("\b \b");
                }
                else if ("0123456789.-".Contains(key.KeyChar)) {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
                else {
                    Console.Beep();
                }
            }
        }
