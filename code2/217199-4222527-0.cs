    [Conditional("DEBUG")]
    public static void Assert(bool condition, string message)
    {
        if (!condition)
            throw new InvalidStateException("Assertion failed: " + message);
    }
