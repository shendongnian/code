    public static int[] ToIntArray(long l)
    {
        var longBytes = BitConverter.GetBytes(l);
    
        // Get integers from the first and the last 4 bytes of long
        return new int[] {
            BitConverter.ToInt32(longBytes, 0),
            BitConverter.ToInt32(longBytes, 4)
        };
    }
