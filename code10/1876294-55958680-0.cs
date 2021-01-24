    public class Author
    {
        public string name { get; set; }
    }
    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
    public class Link2
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
    public class Properties
    {
        public string r_object_id { get; set; }
        public string object_name { get; set; }
    }
    public class Link3
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
    public class Content
    {
        public string json_root { get; set; }
        public string definition { get; set; }
        public Properties properties { get; set; }
        public List<Link3> links { get; set; }
    }
    public class Entry
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime updated { get; set; }
        public DateTime published { get; set; }
        public List<Link2> links { get; set; }
        public Content content { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<Author> author { get; set; }
        public DateTime updated { get; set; }
        public int page { get; set; }
        public int items_per_page { get; set; }
        public List<Link> links { get; set; }
        public List<Entry> entries { get; set; }
    }
