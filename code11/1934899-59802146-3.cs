    class Person {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Gender { get; set; }
        }
