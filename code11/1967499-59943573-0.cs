public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            // HER DOSYAYI YENI DIZINE KOPYALAR
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(System.IO.Path.Combine(target.FullName, fi.Name), true);
            }
            // HER ALT DIZINI KOPYALAR
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        void CopyFile(string source, string des)
        {
            FileStream fsout = new FileStream(des, FileMode.Create);
            FileStream fsIn = new FileStream(source, FileMode.Open);
            byte[] bt = new byte[1048756];
            int readByte;
            while ((readByte=fsIn.Read(bt,  0,  bt.Length))>0)
            {
                fsout.Write(bt, 0, readByte);
                worker.ReportProgress((int)(fsIn.Position*100/fsIn.Length));
            }
            fsIn.Close();
            fsout.Close();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyAll(new DirectoryInfo( txtSource.Text), new DirectoryInfo(txtTarget.Text));
        }
I add my github repository:https://github.com/yusufcelik1/Copy-Folder.git
