    IEnumerable<byte> bytesEnumerable = GetBytesFromList(list);
    byte[] newArray = bytesEnumerable.ToArray();
    private static IEnumerable<byte> GetBytesFromList(List<byte[]> list)
    {
        foreach (byte[] bytes in list)
        {
            foreach (byte b in bytes)
            {
                yield return b;
            }
        }
    }
