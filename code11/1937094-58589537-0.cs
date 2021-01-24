    class ViewModel
    {
        private Album _album;
    
        public ObservableCollection<Album> Albums { get; private set; }
    
        public ObservableCollection<Album> AlbumSongs { get; private set; }
    
        public Album SelectedAlbum
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
                LoadAlbumSongs(album);
            }
        }
    
        public Song SelectedSong { get; set; }
    
        public ViewModel()
        {
            Albums = new ObservableCollection<Album>(); //Load albums here
        }
    
        public void AddNewAlbum()
        {
            SelectedAlbum = new Album();
        }
    
        public void AddNewSong()
        {
            SelectedAlbum = new Album();
            SelectedSong.AlbumID = SelectedAlbum.ID;
        }
    
        public void SaveAlbum()
        {
            //Save SelectedAlbum and add new album to Albums Collection
        }
    
        public void SaveSong()
        {
            //Save SelectedSong and add new song to AlbumSongs Collection
        }
    }
