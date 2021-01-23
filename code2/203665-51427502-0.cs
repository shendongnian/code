            String directoryName = @"D:\NewAll\";
            DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(directoryName);
            List<String> AllFiles= Directory
                               .GetFiles(@"D:\SourceDirectory\", "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in AllFiles)
            {
                FileInfo mFile = new FileInfo(file);
                // to remove name collisions
                if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                {
                    mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                }
                else
                {
                    string s = mFile.Name.Substring(0, mFile.Name.LastIndexOf('.'));
                    int a = 0;
                    while (new FileInfo(dirInfo + "\\" + s + a.ToString() + mFile.Extension).Exists)
                    {
                        a++;
                    }
                    mFile.MoveTo(dirInfo + "\\" + s + a.ToString() + mFile.Extension);
                }
            }
