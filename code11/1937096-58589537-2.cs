    class ViewModel : BindableBase
    {
        private IDatabase _database;
        private Album _album;
        private Song _song;
        public ObservableCollection<Album> Albums { get; private set; }
        public ObservableCollection<Song> AlbumSongs { get; private set; }
    
        public ICommand AddAlbumCommand {get; private set;}
        public ICommand AddSongCommand {get; private set;}
    
        public Album SelectedAlbum
        {
            get => _album;
            set { LoadAlbumSongs(album); SetProperty(ref _album, value); }
        }
    
        public Song SelectedSong
        {
            get => _song;
            set => SetProperty(ref _song, value);
        }
    
        public ViewModel(IDatabase database)
        {
            _database = database;
            Albums = new ObservableCollection<Album>();
            AlbumSongs = new ObservableCollection<Song>();
    
            AddAlbumCommand = new RelayCommand (() => AddNewAlbum(),  () => true);
            AddSongCommand = new RelayCommand (() => AddNewSong(),  () => SelectedAlbum != null);
        }
        public void AddNewAlbum()
        {
            SelectedAlbum = new Album();
        }
    
        public void AddNewSong()
        {
            SelectedSong = new Song();
            SelectedSong.AlbumID = SelectedAlbum.AlbumID;
        }
    
        public void SaveAlbum()
        {
            if (SelectedAlbum.ID == 0) {
                Albums.Add(SelectedAlbum);
            }
            _database.SaveAlbum(SelectedAlbum);
        }
    
        public void SaveSong()
        {
            if (SelectedSong.ID == 0) {
                AlbumSongs.Add(SelectedSong);
            }
            _database.SaveSong(SelectedSong);
        }
    }
