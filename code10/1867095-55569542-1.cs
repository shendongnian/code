        //Call this function instad of SaveFileDialog.Show()
        void showSaveDialog()
        {
            //Open dialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            //check if file exists
            if (!File.Exists(sfd.FileName))
            {
                return;
            }
            // get the harddrive the user is saving on and get the free space
            string drive = System.IO.Path.GetPathRoot(sfd.FileName);
            double freeSpace = getFreeSpace(drive);
            double filesize = new System.IO.FileInfo(sfd.FileName).Length;
            
            //Messagebox if the is not enought space and restart
            if (  filesize > freeSpace)
            {
                MessageBox.Show($"Not enough free space on harddrive {drive}...\nFree space was {freeSpace} and file was {filesize}","Storage Error");
                showSaveDialog();
            }
            else
            {
                //save your file here
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
