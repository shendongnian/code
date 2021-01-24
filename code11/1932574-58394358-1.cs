    public bool M(ulong a, ulong? b)
    {
        ulong? num = b;
        return (a == num.GetValueOrDefault()) & num.HasValue;
    }
