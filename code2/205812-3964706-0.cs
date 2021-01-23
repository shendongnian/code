    public static byte[] ReadWholeFileBytes(string filename)
    {
        Guard.ArgumentNotNullOrEmptyString(filename, "filename");
        if(!File.Exists(filename))
        {
            throw new FileNotFoundException("Failed finding file " + filename);
        }
        using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            return ReadWholeStream(stream);
        }
    }
