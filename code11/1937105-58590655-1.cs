     public class FileActionEntry
    {
        public int NumberX { get; set; }
        public string ActionX { get; set; }
        public string FileX { get; set; }
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _searchText = "";
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText == value)
                {
                    return;
                }
                _searchText = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<FileActionEntry> _fileActionEntryCollection = new ObservableCollection<FileActionEntry>()
        {
            new FileActionEntry(){ ActionX = "Moved", FileX = "File1", NumberX = 1},
            new FileActionEntry(){ ActionX = "Renamed", FileX = "File2", NumberX = 2},
            new FileActionEntry(){ ActionX = "Removed", FileX = "File3", NumberX = 3}
        };
        public ObservableCollection<FileActionEntry> FileActionEntryCollection
        {
            get
            {
                return _fileActionEntryCollection;
            }
            set
            {
                if (_fileActionEntryCollection == value)
                {
                    return;
                }
                _fileActionEntryCollection = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (FileActionEntryCollection.Any(f => f.FileX == SearchText))
                FileActionEntryCollection.Remove(FileActionEntryCollection.First(f => f.FileX == SearchText));
        }
    }
