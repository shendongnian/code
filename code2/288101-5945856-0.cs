    public static void ThrowIfNegative(this BigInteger value, string name)
    {
        if (value.Sign < 0)
        {
            throw new ArgumentOutOfRangeException(name);
        }
    }
