    public class Item
        {
            /// <summary>
            /// Property that will be left out of deserialization, but return the Group.Id every time the value is
            /// evaluated.
            /// </summary>
            [JsonIgnore]
            public int GroupId => (int)Group?.Id;
    
            [JsonProperty("id")]
            public int Id { get; set; }
    
            [JsonProperty("description")]
            public string Description { get; set; }
    
            [JsonProperty("group")]
            public Group Group { get; set; }
        }
