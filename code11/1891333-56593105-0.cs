    public class CryptoMultiPriceViewModel
    {
        public Dictionary<string, Dictionary<string, DataInfo>> RAW { get; set; }   
    }
    public class DataInfo
    {
        [JsonProperty(PropertyName = "TYPE")]
        public string dataType { get; set; }
    }
