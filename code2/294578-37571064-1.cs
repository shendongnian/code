           public void PrintAllFiles()
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.Verb = "print";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //Load Files in Selected Folder
            string[] allFiles = System.IO.Directory.GetFiles(Directory);
            foreach (string file in allFiles)
            {
                info.FileName = @file;
                info.CreateNoWindow = true;
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo = info;
                p.Start();
            }
            p.Kill();
            MessageBox.Show("Print Complete");
        }
