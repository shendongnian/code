    public static void Loopy(int level, int maxLevel, int repeat, bool next)
    {
        if (level > maxLevel)
            return;
        for (int i = 0; i < repeat; i++)
        {
            SomeMethod(level, i);
            if (next)
                Loopy(level + 1, maxLevel, repeat, next);
        }
    }
    public static void SomeMethod(int level, int i)
    {
        Console.WriteLine("level: {0}, i: {1}", level, i);
    }
