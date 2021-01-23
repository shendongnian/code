    drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable).ToArray();
            if (drives.Length == 0)
            {
                drivesBox.Items.Add("No USB Stick found.");
                formatButton.Enabled = false;
            }
            else
            {
                foreach (DriveInfo drive in drives)
                {
                    drivesBox.Items.Add(drive.VolumeLabel + " (" + drive.Name + ")");
                }
                formatButton.Enabled = true;
            }
