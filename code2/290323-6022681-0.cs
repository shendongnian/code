        public void SetVolumeLabel(string newLabel)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady && d.DriveType == DriveType.Removable)
                {
                    d.VolumeLabel = newLabel;
                }
            }
        }
        public string VolumeLabel { get; set; }
        // Setting the drive name
        private void button1_Click(object sender, EventArgs e)
        {
            SetVolumeLabel("FlashDrive");
        }
