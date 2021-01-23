    public class ConsoleOutput
    {
        private ConsoleOutputType OutputType { get; set; }
        private object MyObject { get; }
        private static bool IsInserting { get; set; }
        public string KeyName => IsKey() && (ConsoleKeyInfo)MyObject != null ? ((ConsoleKeyInfo)MyObject).Key.ToString() : "Null";
        public string OutputString => !IsKey() && MyObject != null ? (string)MyObject : string.Empty;
        public static event Action<string> ReadInput = delegate { };
        public static event Action<ConsoleKeyInfo> ReadKey = delegate { };
        private ConsoleOutput()
        {
        }
        public ConsoleOutput(object obj)
        {
            MyObject = obj;
            OutputType = obj is ConsoleKeyInfo ? ConsoleOutputType.Key : ConsoleOutputType.Value;
        }
        public bool IsKey()
        {
            return OutputType == ConsoleOutputType.Key;
        }
        public bool IsExitKey()
        {
            if (!IsKey())
                return false;
            var info = ((ConsoleKeyInfo)MyObject);
            return (info.Modifiers & ConsoleModifiers.Control) != 0 && info.Key == ConsoleKey.B;
        }
        public string GetValue()
        {
            return (string)MyObject;
        }
        // returns null if user pressed Escape, or the contents of the line if they pressed Enter.
        public static ConsoleOutput ReadLineOrKey()
        {
            string retString = "";
            int curIndex = 0;
            do
            {
                ConsoleKeyInfo readKeyResult = Console.ReadKey(true);
                // handle Enter
                if (readKeyResult.Key == ConsoleKey.Enter)
                {
                    ReadInput?.Invoke(retString);
                    Console.WriteLine();
                    return new ConsoleOutput(retString);
                }
                // handle backspace
                if (readKeyResult.Key == ConsoleKey.Backspace)
                {
                    if (curIndex > 0)
                    {
                        retString = retString.Remove(retString.Length - 1);
                        Console.Write(readKeyResult.KeyChar);
                        Console.Write(' ');
                        Console.Write(readKeyResult.KeyChar);
                        --curIndex;
                    }
                }
                else if (readKeyResult.Key == ConsoleKey.Delete)
                {
                    if (retString.Length - curIndex > 0)
                    {
                        // Store current position
                        int curLeftPos = Console.CursorLeft;
                        // Redraw string
                        for (int i = curIndex + 1; i < retString.Length; ++i)
                            Console.Write(retString[i]);
                        // Remove last repeated char
                        Console.Write(' ');
                        // Restore position
                        Console.SetCursorPosition(curLeftPos, Console.CursorTop);
                        // Remove string
                        retString = retString.Remove(curIndex, 1);
                    }
                }
                else if (readKeyResult.Key == ConsoleKey.RightArrow)
                {
                    if (curIndex < retString.Length)
                    {
                        ++Console.CursorLeft;
                        ++curIndex;
                    }
                }
                else if (readKeyResult.Key == ConsoleKey.LeftArrow)
                {
                    if (curIndex > 0)
                    {
                        --Console.CursorLeft;
                        --curIndex;
                    }
                }
                else if (readKeyResult.Key == ConsoleKey.Insert)
                {
                    IsInserting = !IsInserting;
                }
    #if DEBUG
                else if (readKeyResult.Key == ConsoleKey.UpArrow)
                {
                    if (Console.CursorTop > 0)
                        --Console.CursorTop;
                }
                else if (readKeyResult.Key == ConsoleKey.DownArrow)
                {
                    if (Console.CursorTop < Console.BufferHeight - 1)
                        ++Console.CursorTop;
                }
    #endif
                else
                // handle all other keypresses
                {
                    if (IsInserting || curIndex == retString.Length)
                    {
                        retString += readKeyResult.KeyChar;
                        Console.Write(readKeyResult.KeyChar);
                        ++curIndex;
                    }
                    else
                    {
                        // Store char
                        char c = readKeyResult.KeyChar;
                        // Write char at position
                        Console.Write(c);
                        // Store cursor position
                        int curLeftPos = Console.CursorLeft;
                        // Clear console from curIndex to end
                        for (int i = curIndex; i < retString.Length; ++i)
                            Console.Write(' ');
                        // Go back
                        Console.SetCursorPosition(curLeftPos, Console.CursorTop);
                        // Write the chars from curIndex to end (with the new appended char)
                        for (int i = curIndex; i < retString.Length; ++i)
                            Console.Write(retString[i]);
                        // Restore again
                        Console.SetCursorPosition(curLeftPos, Console.CursorTop);
                        // Store in the string
                        retString = retString.Insert(curIndex, new string(c, 1));
                        // Sum one to the cur index (we appended one char)
                        ++curIndex;
                    }
                }
                if (char.IsControl(readKeyResult.KeyChar) &&
                    readKeyResult.Key != ConsoleKey.Enter &&
                    readKeyResult.Key != ConsoleKey.Backspace &&
                    readKeyResult.Key != ConsoleKey.Tab &&
                    readKeyResult.Key != ConsoleKey.Delete &&
                    readKeyResult.Key != ConsoleKey.RightArrow &&
                    readKeyResult.Key != ConsoleKey.LeftArrow &&
                    readKeyResult.Key != ConsoleKey.Insert)
                {
    #if DEBUG
                    if (readKeyResult.Key == ConsoleKey.UpArrow || readKeyResult.Key == ConsoleKey.DownArrow)
                        continue;
    #endif
                    ReadKey?.Invoke(readKeyResult);
                    Console.WriteLine();
                    return new ConsoleOutput(readKeyResult);
                }
            }
            while (true);
        }
    }
