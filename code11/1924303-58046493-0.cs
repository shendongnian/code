    public partial class Root
    {
        public long Version { get; set; }
        public Mangas[] Mangas { get; set; }
    }
    public partial class Mangas
    {
        public Manga[] Manga { get; set; }
        
    }
    public partial class Chapter
    {
        public string U { get; set; }
        public long R { get; set; }
    }
    public partial struct Manga
    {
        public long? Integer;
        public string String;
		public Chapter[] Chapters { get; set; }
    }
