    public class StoreManagerViewModel
    {
        public Album Album { get; set; }
        public int? SelectedArtistId { get; set; }
        public List<Artist> Artists { get; set; }
        public int? SelectedGenreId { get; set; }
        public List<Genre> Genres { get; set; }
    }
