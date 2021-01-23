    public void UseOperator(string name, Func<int, int, bool> op, int value)
    {
        ...
    }
    public static bool GreaterThan(int x, int y, value)
    {
        return x > y;
    }
    UseOperator("test", GreaterThan, 0);
