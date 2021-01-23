    public static bool IsNetworkPath(string path)
    {
        if (System.IO.Path.IsPathRooted(path))
        {
            string rootPath = System.IO.Path.GetPathRoot(path); // get drive's letter
            System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(rootPath); // get info about the drive
            return driveInfo.DriveType == DriveType.Network; // return true if a network drive
        }
        
        return true; // is a UNC path
    }
