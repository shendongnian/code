    class MyDictionaryItem
    {
        [JsonProperty("primaryKey")]
        public string PrimaryKey { get; set; }
        [JsonProperty("secondaryKey")]
        public string SecondaryKey { get; set; }
    }
    var myResult = JsonConvert.DeserializeObject<MyDictionaryItem>(responseString);
