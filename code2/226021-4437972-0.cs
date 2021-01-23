    DriveInfo[] mydrives = DriveInfo.GetDrives();
            foreach (DriveInfo mydrive in mydrives)
            {
                if (mydrive.DriveType == DriveType.Removable)
                {
                    Console.WriteLine("\nRemovable disk");
                    Console.WriteLine("Drive: {0}", mydrive.Name);
                    Console.WriteLine("Type: {0}", mydrive.DriveType);                    
                }
                else
                {
                    Console.WriteLine("\nNon Removable disk\n");
                    Console.WriteLine("Drive: {0}", mydrive.Name);
                    Console.WriteLine("Type: {0}", mydrive.DriveType);                   
                }
            }
