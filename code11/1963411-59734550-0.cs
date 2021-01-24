    static string ReadAtBegin(string staticText)
    {
        string input = "";
        ConsoleKeyInfo key;
        int top = Console.CursorTop;
        int left = Console.CursorLeft;
        Console.Write(staticText);
        do
        {
            key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
                Console.SetCursorPosition(left, top);
                Console.Write(input + staticText); 
            }
            else
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(input + staticText);
            }
        } while (key.Key != ConsoleKey.Enter);
        return input;
    }
