    public class Chapter
    {
        [JsonProperty("u")]
        public string U { get; set; }
        [JsonProperty("r")]
        public int R { get; set; }
    }
    public class Manga
    {
        [JsonProperty("manga")]
        public IList<object> MangaInfos { get; set; }
        [JsonProperty("chapters")]
        public IList<Chapter> Chapters { get; set; }
    }
    public class Example
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("mangas")]
        public IList<Manga> Mangas { get; set; }
    }
