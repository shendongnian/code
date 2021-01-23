    public static LoopMethod(int iterations, Action<int> body)
    {
        for (int i = 0; i < iterations; i++)
            body(i);
    }
