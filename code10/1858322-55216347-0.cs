    public class MyMovieData
    {
        [JsonProperty("streams"]
        public MovieStream[] Streams { get; set; }
    }
    public class MovieStream[]
    {
        [JsonProperty("codec_name")]
        public string CodecName { get; set; }
        [JsonProperty("codec_type")]
        public string CodecType { get; set; }
    }
