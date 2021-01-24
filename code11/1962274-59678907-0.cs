    public static void ExtractMessageHeaderOld(ReadOnlySequence<byte> ros, out MessageHeader messageHeader)
    {
        Span<byte> stackSpan = stackalloc byte[(int)ros.Length];
        ros.CopyTo(stackSpan);
        ReadOnlySpan<MessageHeader> mhSpan = MemoryMarshal.Cast<byte, MessageHeader>(stackSpan);
        messageHeader = mhSpan[0];
    }
