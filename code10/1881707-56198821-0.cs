    private static int aBtn;
    public static int ABtn
    {
        get => aBtn;
        set => aBtn = CheckArgumentRange(nameof(value), value, 0, 5);
    }
    internal static int CheckArgumentRange(
        string paramName, int value, int minInclusive, int maxInclusive)
    {
        if (value < minInclusive || value > maxInclusive)
        {
            throw new ArgumentOutOfRangeException(paramName, value,
                $"Value should be in range [{minInclusive}-{maxInclusive}]");
        }
            
        return value;
    }
