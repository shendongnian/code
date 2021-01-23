    public static class FileAttrProvider
    {
    
    private static FileAttrReader _reader = null;
    
    public static void Initialize()
    {
        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.MacOSX:
                goto case PlatformID.Unix;
            case PlatformID.Unix:
                _reader = new FileAttrReaderUnix();
                break;
            case PlatformID.Win32NT:
                _reader = new FileAttrReaderDos();
                break;
        }
    }
    }
