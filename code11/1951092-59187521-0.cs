        public class PriceInfo
    {
        [JsonProperty("mtgo")] public Dictionary<string, decimal> mtgo { get; set; }
        [JsonProperty("mtgoFoil")] public Dictionary<string, decimal> mtgof { get; set; }
        [JsonProperty("paper")] public Dictionary<string, decimal> RegPrice { get; set; }
        [JsonProperty("paperFoil")] public Dictionary<string, decimal> FoilPrice { get; set; }
    }
