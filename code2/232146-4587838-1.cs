    public static void Loopy(int level, int maxLevel, int repeat)
    {
        if (level > maxLevel)
            return;
        for (int i = 0; i < repeat; i++)
        {
            if (SomeMethod(level, i);)
                Loopy(level + 1, maxLevel, repeat);
        }
    }
    public static bool SomeMethod(int level, int i)
    {
        Console.WriteLine("level: {0}, i: {1}", level, i);
        return ...
    }
