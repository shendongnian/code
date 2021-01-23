    public class DatabaseRecord : INotifyPropertyChanged 
    {
        private readonly ObservableCollection<string> _includeFolders;
        public ObservableCollection<string> IncludeFolders
        {
            get { return _includeFolders; }
        }
        public DatabaseRecord()
        {
            _includeFolders = new ObservableCollection<string>();
            _includeFolders.CollectionChanged += IncludeFolders_CollectionChanged;
        }
        private void IncludeFolders_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Notify("IncludeFolders");
        }
        ...
    }
