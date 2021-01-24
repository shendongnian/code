     string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            DirectoryInfo downloadDir = new DirectoryInfo(pathDownload);
            FileInfo[] files = downloadDir.GetFiles("*.pdf");
            var filename = files[0].FullName;
            string getFileName = Path.GetFileName(filename);
            if (File.Exists(filename))
            {
                Console.WriteLine("The file has been downloaded successfully");
                Console.WriteLine("The filename is: " + getFileName);
            }
            File.Delete(filename);
Hope it helps someone.
