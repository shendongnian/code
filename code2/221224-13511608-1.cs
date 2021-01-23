    public static bool IsNetworkPath(string path)
    {
        if (!path.StartsWith(@"/") && !path.StartsWith(@"\"))
        {
            string rootPath = System.IO.Path.GetPathRoot(path); // get drive's letter
            System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(rootPath); // get info about the drive
            return driveInfo.DriveType == DriveType.Network; // return true if a network drive
        }
        
        return true; // is a UNC path
    }
