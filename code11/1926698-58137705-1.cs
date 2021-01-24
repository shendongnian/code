    [JsonConverter(typeof(CollectionJsonConverter))]
    class CollectionResponse<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
