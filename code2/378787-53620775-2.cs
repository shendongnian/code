    public static UInt64 ReadIntFromByteArray(Byte[] data, Int32 startIndex, Int32 bytes, Boolean littleEndian)
    {
        Int32 lastByte = bytes - 1;
        if (data.Length < startIndex + bytes)
            throw new ArgumentOutOfRangeException("startIndex", "Data array is too small to read a " + bytes + "-byte value at offset " + startIndex + ".");
        UInt64 value = 0;
        for (Int32 index = 0; index < bytes; index++)
        {
            Int32 offs = startIndex + (littleEndian ? index : lastByte - index);
            value += (UInt64)(data[offs] << (8 * index));
        }
        return value;
    }
