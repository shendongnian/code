    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
