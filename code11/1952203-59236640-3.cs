    public void FastUnescape(ReadOnlySpan<byte> source, Span<byte> destination)
    {
        if (source.Length <= destination.Length)
        {
            Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(source), destination);
        }
    }
