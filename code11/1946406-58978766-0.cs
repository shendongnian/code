    public class Name
    {
        public string label { get; set; }
    }
    public class Uri
    {
        public string label { get; set; }
    }
    public class Author
    {
        public Name name { get; set; }
        public Uri uri { get; set; }
    }
    public class Uri2
    {
        public string label { get; set; }
    }
    public class Name2
    {
        public string label { get; set; }
    }
    public class Author2
    {
        public Uri2 uri { get; set; }
        public Name2 name { get; set; }
        public string label { get; set; }
    }
    public class ImVersion
    {
        public string label { get; set; }
    }
    public class ImRating
    {
        public string label { get; set; }
    }
    public class Id
    {
        public string label { get; set; }
    }
    public class Title
    {
        public string label { get; set; }
    }
    public class Attributes
    {
        public string type { get; set; }
    }
    public class Content
    {
        public string label { get; set; }
        public Attributes attributes { get; set; }
    }
    public class Attributes2
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
    public class Link
    {
        public Attributes2 attributes { get; set; }
    }
    public class ImVoteSum
    {
        public string label { get; set; }
    }
    public class Attributes3
    {
        public string term { get; set; }
        public string label { get; set; }
    }
    public class ImContentType
    {
        public Attributes3 attributes { get; set; }
    }
    public class ImVoteCount
    {
        public string label { get; set; }
    }
    public class Entry
    {
        public Author2 author { get; set; }
        [JsonProperty(PropertyName = "im:version")]
        public ImVersion imversion { get; set; }
        [JsonProperty(PropertyName = "im:rating")]
        public ImRating imrating { get; set; }
        public Id id { get; set; }
        public Title title { get; set; }
        public Content content { get; set; }
        public Link link { get; set; }
        [JsonProperty(PropertyName = "im:voteSum")]
        public ImVoteSum imvoteSum { get; set; }
        [JsonProperty(PropertyName = "im:contentType")]
        public ImContentType imcontentType { get; set; }
        [JsonProperty(PropertyName = "im:voteCount")]
        public ImVoteCount imvoteCount { get; set; }
    }
    public class Feed
    {
        public Author author { get; set; }
        public List<Entry> entry { get; set; }
    }
    public class RootObject5
    {
        public Feed feed { get; set; }
    }
