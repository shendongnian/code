    // Let's assume you'll never really need more than this
    private static readonly byte[] LargeJunkArray = new byte[1024 * 32];
    public static bool SecureEquals(byte[] original, byte[] potential)
    {
        // Reveal that the original array will never be more than 32K.
        // This is unlikely to be particularly useful.
        if (potential.Length > LargeJunkArray.Length)
        {
            return false;
        }
        byte[] copy = new byte[potential.Length];
        int bytesFromOriginal = Math.Min(original.Length, copy.Length);
        // Always copy the same amount of data
        Array.Copy(original, 0, copy, 0, bytesFromOriginal);
        Array.Copy(LargeJunkArray, 0, copy, bytesFromOriginal,
                   copy.Length - bytesFromOriginal);
    
        bool isEqual = original.Length == potential.Length;
        for(int i=0; i < copy.Length; i++)
        {
            isEqual = isEqual & (copy[i] == potential[i]);
        }
    
        return isEqual;
    }
