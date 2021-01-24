    public static void AnotherMethod(ReadOnlySpan<byte> source, Span<byte> destination)
    {
        for (int i = 0; i < source.Length; i++)
        {
            destination[i] = (byte) (Convert.ToChar(source[i]));
        }
    }
