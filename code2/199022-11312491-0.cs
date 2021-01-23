        private void del_IE_files()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            //for deleting files
            System.IO.DirectoryInfo DInfo = new DirectoryInfo(path);
            FileAttributes Attr = DInfo.Attributes;
            DInfo.Attributes = FileAttributes.Normal;
            foreach (FileInfo file in DInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in DInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true); //delete subdirectories and files
                }
                catch
                {
                    
                }
            }
        }
