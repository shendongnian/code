    public class Document
    {
        public string Number { get; set; }
        public string Revision { get; set; }
        public string FileName { get; set; }
        // Specify a custom JsonConverter for our StreamJsonConverter
        [JsonConverter(typeof(StreamStringConverter))]
        public Stream File { get; set; }
    }
