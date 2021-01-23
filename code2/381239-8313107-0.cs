       public static int FreeDriveSpace()
       {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true && d.TotalFreeSpace >= 32212254720)
                {
                    return 1; // the control only reaches this return statement if a drive with more than 30GB free space is found
                }
    
            }
            // if the control reaches here, it means the if test failed for all drives. so return 0.
            return 0; 
        }
