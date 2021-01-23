     using System.IO;
// . . .
            foreach (DriveInfo removableDrive in DriveInfo.GetDrives().Where(
                d => d.DriveType == DriveType.Removable && d.IsReady))
            {
                DirectoryInfo rootDirectory = removableDrive.RootDirectory;
                string monitoredDirectory = Path.Combine(rootDirectory.FullName, DIRECTORY_TO_MONITOR);
                string localDestDirectory = Path.Combine(destDirectory, removableDrive.VolumeLabel);
                if (!Directory.Exists(localDestDirectory))
                    Directory.CreateDirectory(localDestDirectory);
                if (Directory.Exists(monitoredDirectory))
                {
                    foreach (string file in Directory.GetFiles(monitoredDirectory))
                    {
                        File.Copy(file, Path.Combine(localDestDirectory, Path.GetFileName(file)), true);
                    }
                }
            }
