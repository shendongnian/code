    /// <summary>
    /// Reads data from a stream until the end is reached. The
    /// data is returned as a byte array. An IOException is
    /// thrown if any of the underlying IO calls fail.
    /// </summary>
    /// <param name="stream">The stream to read data from</param>
    public static byte[] ReadFully (Stream stream)
    {
        byte[] buffer = new byte[32768];
        using (MemoryStream ms = new MemoryStream())
        {
            while (true)
            {
                int read = stream.Read (buffer, 0, buffer.Length);
                if (read <= 0)
                    return ms.ToArray();
                ms.Write (buffer, 0, read);
            }
        }
    }
