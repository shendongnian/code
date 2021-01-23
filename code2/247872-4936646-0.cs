    private int _processDirTrack = 0;
    
    public void ProcessDir(string sourceDir)
    {
        _processDirTrack++;  // Increment at the start of each
    
        string[] fileEntries = Directory.GetFiles(sourceDir, "*.mp3");
        foreach (string fileName in fileEntries)
        {
            Song newSong = new Song();
            newSong.ArtistName = "test artist";
            newSong.AlbumName = "test album";
            newSong.Name = "test song title";
            newSong.Length = 1234;
            newSong.FileName = fileName;
    
            songsCollection.Songs.Add(newSong);
        }
    
        string[] subdirEntries = Directory.GetDirectories(sourceDir);
        foreach (string subdir in subdirEntries)
        {
            if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
                ProcessDir(subdir);
            }
        }
    
        _processDirTrack--;  // Decrement after the recursion. Fall through means it got to
                             // the end of a branch
    
        if(_processDirTrack == 0)
        {
            Console.WriteLine("I've finished with all of them.");
        }
    }
