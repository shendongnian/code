    public class Event
    {
        public string id { get; set; }
        public string date { get; set; }
        public string date_gmt { get; set; }
        public guid guid { get; set; }
        public string modified { get; set; }
        public string modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public title title { get; set; }
        public content content { get; set; }
        public string featured_media { get; set; }
        public string template { get; set; }
    }
    public class guid
    {
        public string rendered { get; set; }
    }
    public class title
    {
        public string rendered { get; set; }
    }
    public class content
    {
        public string rendered { get; set; }
        public string @protected { get; set; } //@ to ignore the keyword protected
    }
