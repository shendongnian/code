    public class AlbumData : ViewModelBase
    {
        public AlbumData(string albumName, ObservableCollection<FileData> albumFileList)
        {
            if (string.IsNullOrEmpty(albumName) || albumFileList == null)
            {
                return;
            }
            AlbumName = albumName;
            AlbumFiles = albumFileList;
        }
        public string AlbumName { get; set; } = "";
        private ObservableCollection<FileData> _AlbumFiles = new ObservableCollection<FileData>();
        public ObservableCollection<FileData> AlbumFiles
        {
            get
            {
                return _AlbumFiles;
            }
            set
            {
                _AlbumFiles = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AlbumFiles"));
            }
        }
    }
