    public class BlobModel
    {
            [JsonProperty("@search.score")]
            public float searchscore { get; set; }
    
            [JsonProperty("content")]
            public string Content { get; set; }
    
            [JsonProperty("metadata_storage_content_type")]
            public string MetadataStorageContentType { get; set; }
    
            [JsonProperty("metadata_storage_size")]
            public int MetadataStorageSize { get; set; }
    
            [JsonProperty("metadata_storage_last_modified")]
            public DateTime MetadataStorageLastModified { get; set; }
    
            [JsonProperty("metadata_storage_content_md5")]
            public string MetadataStorageContentMd5 { get; set; }
    
            [JsonProperty("metadata_storage_name")]
            public string MetadataStorageName { get; set; }
    
            [JsonProperty("metadata_storage_path")]
            public string MetadataStoragePath { get; set; }
    
            [JsonProperty("metadata_title")]
            public string MetadataTitle { get; set; }
    
            [JsonProperty("metadata_content_encoding")]
    	    public string MetadataContentEncoding { get; set; }
    }
