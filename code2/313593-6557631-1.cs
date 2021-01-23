    // define song object.
    public class Song 
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string TrackTitle { get; set; }
        public string AlbumArtwork { get; set; }
    }
    // create list of songs.
    List<Song> songs = new List<Song>();
    // add new song to list.
    songs.Add(new Song {
            FileLocation = "/filepath/sade.mp3",
            FileName = "Sade", 
            Artist = "Sade", 
            Album = "Sade", 
            TrackTitle = "Smooth Operator", 
            AlbumArtwork "TBD"
    });
    // access first song in list.
    Song song = songs[0];
    // access property of song.
    string trackTitle = song.TrackTitle;
