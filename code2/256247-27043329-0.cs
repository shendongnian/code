        public List<DirectoryInfo> getDirectoryStructure()
        {
            List<DirectoryInfo> drives = new List<DirectoryInfo>();
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string dr in drives)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                // Here we skip the drive if it is not ready to be read. This
                // is not necessarily the appropriate action in all scenarios.
                if (!di.IsReady)
                {
                    continue;
                }
                drives.Add( di.RootDirectory);
            }
            return drives
        }
