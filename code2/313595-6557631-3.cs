    public class Album
    {
        public string Name
        public DateTime ReleaseDate
        public string Artwork { get; set; }
    }
    
    public class Artist
    {
        public string Name
        public List<Album> Albums
    }
    public class Song 
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public Artist Artist { get; set; }
        public string TrackTitle { get; set; }
    }
