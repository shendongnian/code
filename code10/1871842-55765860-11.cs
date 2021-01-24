    private static char GetCharFromUser(string prompt, Func<char, bool> validator = null)
    {
        char result;
        var cursorTop = Console.CursorTop;
        do
        {
            ClearSpecificLineAndWrite(cursorTop, prompt);
            result = Console.ReadKey().KeyChar;
        } while (!(validator?.Invoke(result) ?? true));
        Console.WriteLine();
        return result;
    }
    private static int GetIntFromUser(string prompt, Func<int, bool> validator = null)
    {
        int result;
        var cursorTop = Console.CursorTop;
        do
        {
            ClearSpecificLineAndWrite(cursorTop, prompt);
        } while (!int.TryParse(Console.ReadLine(), out result) ||
                    !(validator?.Invoke(result) ?? true));
        return result;
    }
    private static void ClearSpecificLineAndWrite(int cursorTop, string message)
    {
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(message);
    }
