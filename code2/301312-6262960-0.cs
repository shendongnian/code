    public class Album
    {
        public int AlbumID { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public IOrderedEnumerable<Song> SortedSongs {
            get { return Songs.OrderBy(s => s.TrackNumber); }
        }
    }
