    public static byte[] CopyToArray(this Stream input)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            input.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
