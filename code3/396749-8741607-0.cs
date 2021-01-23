    byte[] buf;
    using (MemoryStream data = new MemoryStream())
    {
        using (Stream file = TestStream())
        {
            file.CopyTo(data);
            buf = data.ToArray();
        }
    }
    // Use buf
