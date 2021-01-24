    /*this was the best i could do couldn't find way for the class to pass the details i wanted this was the best i could find*/    
    
    private void CheckDrive()
        {
            //string[] dvdDrives = new Cls_DVD_Player.DVDDrvCtrls();
    
            //List<string> drvNames = new List<string>();
            DriveInfo[] cdDrives = DriveInfo.GetDrives();
            cboDrive.Items.Clear();
    
            foreach (DriveInfo d in cdDrives)
            {
                if (d.DriveType == DriveType.CDRom && d.IsReady)
                {
                    cboDrive.Items.Add(d.Name + " " + d.VolumeLabel);
                    //drvNames.Add(d.Name + " " + d.VolumeLabel);
                    //MessageBox.Show(d.Name + " " + d.VolumeLabel);
                }
                else if (d.DriveType == DriveType.CDRom)
                {
                    cboDrive.Items.Add(d.Name + " Drive Empty");
                }
            }
        }
