    static void WriteGenericArgumentType(Action<string> action)
    {
        Action<object> action2 = action;
        Console.WriteLine(DiscoverGenericArgumentType(action).Name);
        Console.WriteLine(DiscoverGenericArgumentType(action2).Name);
    }
