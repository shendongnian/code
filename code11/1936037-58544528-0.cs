    public class Feed
    {
        public string Name { get; set; }
        public byte NumberOfEpisodes { get; set; }
        [XmlArrayItem("Episode")]
        public List<Episode> Episodes { get; set; }
    }
    public class Episode
    {
        public byte EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
