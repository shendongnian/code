    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
     
        [Timestamp]
        public virtual byte[] Version { get; set; }
    }
