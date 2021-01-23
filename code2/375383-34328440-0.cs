    public void ProcessFile(string filepath)
        {
            var fileN ="newfilename";
            string destfile = "E:\\2nd folder" + fileN;
            File.Copy(filepath, destfile, true);
        }
        protected override void OnStart(string[] args)
        {
           String[] files = Directory.GetFiles("E:\\", "*.*");
            foreach (string file in files)
            {
                ProcessFile(file);
            }
            var fw = new FileSystemWatcher("folderpath");
            fw.IncludeSubdirectories = false;
            fw.EnableRaisingEvents = true;
            fw.Created += Newfileevent;
        }
        static void Newfileevent(object sender, FileSystemEventArgs e)
        {
            ProcessFile(e.FullPath);
        }
