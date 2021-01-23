    public class BackupFolder
    {
        private string folderPath;
        public BackupFolder(string folderPath)
        {
            this.folderPath = folderPath;
            FolderName = folderPath.Split(new[] { '\\' }).Last();
        }
        public string FolderName { get; private set; }
    }
