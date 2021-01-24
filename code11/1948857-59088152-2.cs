    public class ImageContentsParams
    {
        [JsonProperty("file_name")] 
        public string FileName { get; set; }
        
        [JsonProperty("contents")] 
        public string Contents { get; set; }
    }
