    public static int GetIntFromUser(string prompt, Func<int, bool> validator = null)
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
