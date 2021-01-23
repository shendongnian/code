    byte[] result = new byte[list.Sum(a => a.Length)];
    using(var stream = new MemoryStream(result))
    {
        foreach (byte[] bytes in list)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
    return result;
