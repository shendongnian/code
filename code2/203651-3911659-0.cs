            List<String> MyMusicFiles = Directory.GetFiles("c:\\Music", "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in MyMusicFiles)
            {
                FileInfo mFile = new FileInfo(file);
                mFile.MoveTo(Application.StartupPath+"\\Consolidated" + mFile.Name);
            }
