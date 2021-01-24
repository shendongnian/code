    while (true)
    {
        title = reader.ReadLine();
        if (title == null) break;
        artist = reader.ReadLine();
        length = reader.ReadLine();
        genre = reader.ReadLine();
        songs.Add(new Song(title, 
                           artist, 
                           Convert.ToDouble(length), 
                           (SongGenre)Enum.Parse(typeof(SongGenre), 
                           genre)));
    }
