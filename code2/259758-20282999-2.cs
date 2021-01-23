    public class FacebookAttachment
        {
            [JsonProperty("attachment")]
            public Attachment Attachment { get; set; }
            [JsonProperty("permalink")]
            public string Permalink { get; set; }
        }
    public class Attachment
        {
            [JsonProperty("media")]
            public Media Media { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("caption")]
            public string Caption { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("properties")]
            public Properties Properties { get; set; }
            [JsonProperty("icon")]
            public string Icon { get; set; }
            [JsonProperty("fb_object_type")]
            public string FbObjectType { get; set; }
        }
     public class Media
        {
        }
     public class Properties
        {
        }
