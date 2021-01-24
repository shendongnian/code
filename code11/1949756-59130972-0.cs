c#
    class JsonExample
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("iso_639_1")]
        public string ISO6391 { get; set; }
        [JsonProperty("iso_3166_1")]
        public string ISO31661 { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        //This would be in your main class not your model but for brevity..
        public static List<JsonExample> GetListOfObjects (string json)
        {
            return JsonConvert.DeserializeObject<List<JsonExample>>(json);
        }
    }
And then get your array / list like this.
c#
var data = "Get your data here";
var list = JsonExample.GetListOfObjects(data);
Good Luck!
