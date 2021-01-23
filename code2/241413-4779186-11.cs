    public const int MaxCount = 0xffffff;
    public unsafe struct ByteArray
    {
        public fixed byte ptr[MaxCount];
    }
