    private static void Log(string text,
                            [CallerFilePath] string file = "",
                            [CallerMemberName] string member = "",
                            [CallerLineNumber] int line = 0)
    {
        Console.WriteLine("{0}_{1}({2}): {3}", Path.GetFileName(file), member, line, text);
    }
