    public class ParentObject
    {
        public Parent parent{ get; set; }
        public GrandP grandp { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> data { get; set; }
    }
