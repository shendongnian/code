    public static byte[] ToByteArray(this int value) {
         var bytes = Enumerable
                         .Range(0, sizeof(int))
                         .Select(index => index * 8)
                         .Select(shift => (byte)((value >> shift) & 0x000000ff))
                         .Reverse()
                         .SkipWhile(b => b == 0x00)
                         .ToArray();
         return bytes;
    }
