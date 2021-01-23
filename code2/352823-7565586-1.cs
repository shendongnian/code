    static string ReadLine(string Default)
    {
        int pos = Console.CursorLeft;
        Console.Write(Default);
        ConsoleKeyInfo info;
        List<char> chars = new List<char> ();
        if (string.IsNullOrEmpty(Default) == false) {
            chars.AddRange(Default.ToCharArray());
        }
        while (true)
        {
            info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
            {
                chars.RemoveAt(chars.Count - 1);
                Console.CursorLeft -= 1;
                Console.Write(' ');
                Console.CursorLeft -= 1;
            }
            else if (info.Key == ConsoleKey.Enter) { Console.Write(Environment.NewLine); break; }
            //Here you need create own checking of symbols
            else if (char.IsLetterOrDigit(info.KeyChar))
            {
                Console.Write(info.KeyChar);
                chars.Add(info.KeyChar);
            }
        }
        return new string(chars.ToArray ());
    }
