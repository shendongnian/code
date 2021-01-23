    public class FileManager
    {
        public AsyncBindingList<string> FilesFolderList = new AsyncBindingList<string>();
        private BackgroundWorker bw = new BackgroundWorker();
        public FileManager()
        {
            bw.DoWork += GetFiles;
        }
        public void GetFiles(string startFolder)
        {
            bw.RunWorkerAsync(startFolder);
        }
        private void GetFiles(object sender, DoWorkEventArgs e)
        {
            var startFolder = e.Argument as string;
            if (startFolder == null)
            {
                e.Cancel = true;
                return;
            }
            var files = Directory.GetFiles(startFolder);
            var validFiles = Array.Find(files, ValidateFile);
            var folders = Directory.GetDirectories(startFolder);
            var folderFiles = Array.ForEach(folders, GetFilesFromFolder);
            FilesFolderList.Add(startFolder);
        }
        private List<string> GetFilesFromFolder()
        {
            return new List<string>();            
        }
        private bool ValidateFile(string FilePath)
        {
            //This Function takes time to validate the file
            return true;
        }        
