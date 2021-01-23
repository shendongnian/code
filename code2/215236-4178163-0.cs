    public Track(string path)
    {
    	if (!File.Exists(path))
    		throw new FileNotFoundException("File not found", path);
    	if (!IsAudioFile(path))
    		throw new InvalidOperationException("Illegal Audio Format");
    	
    	_path = path;
    	_id = Guid.NewGuid();
    	_rate = 0;
    	_length = GetTrackLength(path);
    	
    	TagLib.File file = TagLib.File.Create(path);
    	if (!file.Tag.IsEmpty)
    	{
    		_title = file.Tag.Title;
    	
    		if (file.Tag.Artists != null && file.Tag.Artists.Count > 0)
    			_artist = file.Tag.Artists[0];
    		else
    			_artist = "";
    
    	
    		if (file.Tag.Genres != null && file.Tag.Genres.Count > 0)
    			_genre = file.Tag.Genres[0].ToGenre();
    		else
    			_genre = Genre.NoGenre;
    	}
    	else
    	{
    		_artist = "Unknown";
    		_title = "Unknown";
    		_genre = Genre.NoGenre;
    	}
    }
