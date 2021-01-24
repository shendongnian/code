    public class Videogame
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public DateTime? ReleaseDate { get; set; }
    }
