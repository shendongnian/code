    [DllImport("coredll.dll")]
    private static extern bool SetFileTime(string path,
                                          ref long creationTime,
                                          ref long lastAccessTime,
                                          ref long lastWriteTime);
    public void SetFileTimes(string path, DateTime time)
    {
        var ft = time.ToFileTime();
        SetFileTime(path, ref ft, ref ft, ref ft);
    }
