        void showSaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (!File.Exists(sfd.FileName))
            {
                return;
            }
            string drive = System.IO.Path.GetPathRoot(sfd.FileName);
            double freeSpace = getFreeSpace(drive);
            double filesize = new System.IO.FileInfo(sfd.FileName).Length;
            if (  filesize > freeSpace)
            {
                MessageBox.Show($"Not enough free space on harddrive {drive}...\nFree space was {freeSpace} and file was {filesize}","Storage Error");
                showSaveDialog();
            }
        }
        double getFreeSpace(string drive)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name==drive)
                {
                    return d.AvailableFreeSpace;
                }
            }
            return 0;
        }
