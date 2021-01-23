    static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (Directory.Exists(destFolder)) // check if folder exist
            {
                Directory.Delete(destFolder, true);  // delete folder
                MessageBox.Show("folder " + destFolder + "folder was deleted", "alert");
            }
            Directory.CreateDirectory(destFolder); // create folder
           
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
                FileInfo fileinfo = new FileInfo(dest); // get file attrib
                if (fileinfo.Attributes != FileAttributes.ReadOnly) // check if read only 
                    File.SetAttributes(dest, FileAttributes.Normal);
            }
