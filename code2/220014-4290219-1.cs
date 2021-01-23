    public static unsafe byte[] GetBytes(IList<long> value)
    {
        byte[] buffer = new byte[8 * value.Count];
        fixed (byte* numRef = buffer)
        {
            for (int i = 0; i < value.Count; i++)
                *((long*) (numRef + i * 8)) = value[i];
        }
        return buffer;
    }
