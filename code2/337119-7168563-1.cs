    public static bool IsResizable(this MemoryStream stream)
    {
        if (stream == null) throw new ArgumentNullException("stream");
        bool resizable;
        try
        {
            stream.GetBuffer();
            resizable = true;
        }
        catch (UnauthorizedAccessException) { resizable = false; }
        return resizable;
    }
