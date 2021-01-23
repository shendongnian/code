    private static void InternalAppendAllText(string path, string contents, Encoding encoding)
    {
        using (StreamWriter writer = new StreamWriter(path, true, encoding))
        {
            writer.Write(contents);
        }
    }
