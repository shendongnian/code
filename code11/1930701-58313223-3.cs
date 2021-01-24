    public static string GetStringFromUser(string prompt, 
        Func<string, bool> validator = null)
    {
        string result;
        var cursorTop = Console.CursorTop;
        do
        {
            ClearSpecificLineAndWrite(cursorTop, prompt);
            result = Console.ReadLine();
        } while (!(validator?.Invoke(result) ?? true));
        return result;
    }
    public static int GetIntFromUser(string prompt, 
        Func<int, bool> validator = null)
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
    private static void ClearSpecificLineAndWrite(int cursorTop, 
        string message)
    {
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(message);
    }
