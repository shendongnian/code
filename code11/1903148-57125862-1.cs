    static void Print(int left, int top, params string[] lines)
    {
        foreach (string line in lines)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(line);
            top++;
        }
    }
