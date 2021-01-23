    [OperationContract]
            public List<AllDriveInfo> ServerDriveInfo()
            {
                try
                {
                    DriveInfo[] ComputerDrives = DriveInfo.GetDrives();
                    List<AllDriveInfo> ServerDrives = new List<AllDriveInfo>();
                    foreach (DriveInfo drive in ComputerDrives)
                    {
                        AllDriveInfo NewDrive = new AllDriveInfo();
    
                        NewDrive.DriveLetter = drive.Name.ToString();
    
                        try { NewDrive.VolumeName = drive.VolumeLabel.ToString(); }
                        catch (Exception ex) { NewDrive.VolumeName = " "; }
    
                        try { NewDrive.TotalSpace = Convert.ToDouble(drive.TotalSize) / Math.Pow(1024, 3); }
                        catch (Exception ex) { NewDrive.TotalSpace = 0; }
    
                        try { NewDrive.FreeSpace = Convert.ToDouble(drive.TotalFreeSpace) / Math.Pow(1024, 3); }
                        catch (Exception ex) { NewDrive.FreeSpace = 0; }
    
    
                        ServerDrives.Add(NewDrive);
                    }
                    return ServerDrives;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
