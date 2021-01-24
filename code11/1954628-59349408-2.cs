    static void Main()
    {
        var root = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, ObjInfo>>>(testJson);
        foreach (var item in root)
        {
            Console.WriteLine($"Id: {item.Key}");
            foreach (var subitem in item.Value)
            {
                Console.WriteLine($"    SubCode: {subitem.Key}");
                Console.WriteLine($"        Cost:  {subitem.Value.Cost}");
                Console.WriteLine($"        Count: {subitem.Value.Count}\n");
            }
        }
        // Or access individual items by
        var zeroVk = root[0]["vk"];
        // Console.WriteLine(zeroVk.Cost);
        // Console.WriteLine(zeroVk.Count);
    }
    public class ObjInfo
    {
        [JsonProperty("cost")]
        public int Cost { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
    const string testJson = @"{
    ""0"": {   
    ""vk"": { 
        ""cost"": 19,     
        ""count"": 1903   
    },
    ""ok"": {
        ""cost"": 4,
        ""count"": 2863
    },
    ""wa"": {
        ""cost"": 4,
        ""count"": 2210
    }
    },
    ""1"": {   
    ""vk"": { 
        ""cost"": 11,     
        ""count"": 942   
    },
    ""ok"": {
        ""cost"": 68,
        ""count"": 1153
    },
    ""wa"": {
        ""cost"": 14,
        ""count"": 7643
    }
    }
    }";
