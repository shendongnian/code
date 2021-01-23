    // This will match ParameterizedThreadStart.
    private static void Bar(object x)
    {
        Bar((int)x);
    }
    private static void Bar(int x)
    {
        // do work
    }
