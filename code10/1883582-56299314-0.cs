        [JsonConverter(typeof(JsonSubtypes), "type")]
        [JsonSubtypes.KnownSubType(typeof(Element.Node), "node")]
        [JsonSubtypes.KnownSubType(typeof(Element.Edge), "way")]
    
        public class Element
        {
            public class Node : Element
    
            {
                public string type { get; } = "node";
                public long id { get; set; }
                public float lat { get; set; }
                public float lon { get; set; }
                public NodeTags tags { get; set; }
            }
    
        public class NodeTags : Node
        {
            public string highway { get; set; }
            public string _ref { get; set; }
        }
        
        public class Edge : Element
        {
            public string type { get; } = "way";
            public long id { get; set; }
            public long[] nodes { get; set; }
            public EdgeTags tags { get; set; }
        }
    
        public class EdgeTags : Edge
        {
            [JsonProperty("highway")]
            public string Highway { get; set; }
    
            [JsonProperty("name")]
            public string Name { get; set; }
    
    
            [JsonProperty("tiger:cfcc")]
            public string cfcc { get; set; }
    
            [JsonProperty("tiger:county")]
            public string County { get; set; }
    
            [JsonProperty("oneway")]
            public string Oneway { get; set; }
        }
