    public class FileName : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public FileInfo OriginalFile { get; set; }
        public string FileExtension { get; set; }
        private int _pathLen;
        public int PathLen 
        {
           get { return _pathLen; }
           set 
           { 
              _pathLen = value;
              OnPropertyChanged();
           }
        }
        public string OriginalFileName { get; set; }
        public string NewFileName { get; set; }
        public string OriginalPath { get; set; }
        public string NewPath { get; set; }
        public FileName()
        {
        }
        public FileName(string filename)
        {
            OriginalFile = new FileInfo(filename);
            OriginalPath = NewPath = Path.GetDirectoryName(filename);
            OriginalFileName = NewFileName = Path.GetFileNameWithoutExtension(filename);
            FileExtension = Path.GetExtension(filename);
            PathLen = filename.Length;
        }
        public FileName(FileInfo file)
        {
            OriginalFile = file;
            OriginalPath = NewPath = OriginalFile.DirectoryName;
            OriginalFileName = NewFileName = 
               Path.GetFileNameWithoutExtension(OriginalFile.Name);
            FileExtension = Path.GetExtension(OriginalFile.Name);
            string path = OriginalFile.ToString();
            PathLen = path.Length;
        }
        public string index { get; set; }
        public FileName(WorkBook workbook, string index)
        {
            WorkSheet sheet = workbook.WorkSheets.First();
            foreach (var cell in sheet[index])
            {
                string path = cell.ToString();
                OriginalFile = new FileInfo(path);
                OriginalPath = NewPath = OriginalFile.DirectoryName;
                OriginalFileName = NewFileName = path;
                PathLen = path.Length;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
