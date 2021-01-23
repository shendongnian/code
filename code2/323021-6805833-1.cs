        [SecuritySafeCritical]
    public static void WriteAllText(string path, string contents)
    {
        if (path == null)
        {
            throw new ArgumentNullException("path");
        }
        if (path.Length == 0)
        {
            throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
        }
        InternalWriteAllText(path, contents, StreamWriter.UTF8NoBOM);
    }
    
    
    private static void InternalWriteAllText(string path, string contents, Encoding encoding)
    {
        using (StreamWriter writer = new StreamWriter(path, false, encoding))
        {
            writer.Write(contents);
        }
    }
