    public static MemoryStream CopyToMemory(Stream input)
    {
        // It won't matter if we throw an exception during this method;
        // we don't *really* need to dispose of the MemoryStream, and the
        // caller should dispose of the input stream
        MemoryStream ret = new MemoryStream();
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            ret.Write(buffer, 0, bytesRead);
        }
        // Rewind ready for reading (typical scenario)
        ret.Position = 0;
        return ret;
    }
