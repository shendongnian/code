    public static ulong BitArrayToU64(BitArray ba)
    {
        var len = Math.Min(64, ba.Count);
        ulong n = 0;
        for (int i = 0; i < len; i++) {
            if (ba.Get(i))
                n |= 1UL << i;
        }
        return n;
    }
