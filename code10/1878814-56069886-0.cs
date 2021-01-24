    public class ImageUris
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
    }
    
    public class RootObject
    {
        public string @object { get; set; }
        public string id { get; set; }
        public ImageUris image_uris { get; set; }
    }
