     foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.Removable)
                {
                    Console.WriteLine(di.VolumeLabel);
                }
            }
