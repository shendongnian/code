    foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    // If total free space is more than 30 GB (default)
                    if (d.TotalFreeSpace >= 32212254720) // default: 32212254720
                    {
                        return 1; // If everything is OK it returns 1
                    }
                    else
                    {
                        return 0; // Not enough space returns 0
                    }
                }
    
            }
