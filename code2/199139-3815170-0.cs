    public bool HasAnyBeatlesAlbums {
        get {
            return this.MusicLibrary.Any (cd => cd.Artist == "Beatles");
        }
    }
