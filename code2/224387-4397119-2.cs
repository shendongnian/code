    /// <summary>
    /// Gets the drive type of the given path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>DriveType of path</returns>
    public static DriveType GetPathDriveType(string path)
    {
        //OK, so UNC paths aren't 'drives', but this is still handy
        if(path.StartsWith(@"\\")) return DriveType.Network;  
        var info = 
              DriveInfo.GetDrives()
              Where(i => path.StartsWith(i.Name, StringComparison.OrdinalIgnoreCase))
              FirstOrDefault();
        if(info == null) return DriveType.Unknown;
        return info.DriveType;
    }
