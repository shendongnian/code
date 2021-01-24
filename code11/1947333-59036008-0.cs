    public ReadOnlySpan<byte> Span
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<byte>(Unsafe.AsPointer(ref this), 1);
            }
        }
    }
