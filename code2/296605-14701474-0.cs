    public static void PopulateByteArray(byte[] byteArray, byte value)
    {
        Parallel.For(0, byteArray.Length, i => byteArray[i] = value);
    }
 
