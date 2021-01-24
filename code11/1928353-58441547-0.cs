    public static void CreateDirectoryIfNotExists(string directory, string sharePath, string username, string password)
    {
       NETRESOURCE nr = new NETRESOURCE();
       nr.dwType = ResourceType.RESOURCETYPE_DISK;
       nr.lpLocalName = null;
       nr.lpRemoteName = sharePath;
       nr.lpProvider = null;
    
       int result = WNetAddConnection2(nr, password, username, 0);
       string directoryFullPath = Path.Combine(sharePath, directory);
       if (!Directory.Exists(directoryFullPath))
       {
          Directory.CreateDirectory(directoryFullPath);
       }
    }
