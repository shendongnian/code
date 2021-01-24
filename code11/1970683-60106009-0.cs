    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        _mediaPlaybackList = new MediaPlaybackList();
        SongList = new ObservableCollection<Song>();
        StorageFolder musicLib = KnownFolders.MusicLibrary;
        //file massive
        var files = await musicLib.GetFilesAsync();
        foreach (var file in files)
        {
            var musicProperties = await file.Properties.GetMusicPropertiesAsync();
            var artist = musicProperties.Artist;
            if (artist == "")
                artist = "UnKnown";
            var album = musicProperties.Album;
            if (album == "")
                album = "Unknown";
    
            SongList.Add((new Song { SongName = file.DisplayName, Artist = artist, Album = album, Path = file.Path }));
            MediaPlaybackItem Item = new MediaPlaybackItem(MediaSource.CreateFromStorageFile(file));
            _mediaPlaybackList.Items.Add(Item);
        }
    
            
        mediaElement.SetPlaybackSource(_mediaPlaybackList);
        }
