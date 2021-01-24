            public class Response
            {
                [JsonProperty("data")]
                public Data ResponseData { get; set; }
            }
            public class Data
            {
                [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }
                [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
                public List<Item> Items { get; set; }
            }
            public class Item
            {
                public long? Id { get; set; }
            }
