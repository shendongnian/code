    [System.Serializable]
    public class BTCRootObject
    {   [JsonConverter(typeof(SingleValueArrayConverter<BTCDatum>))] 
        public List<BTCDatum> data { get; set; }
        public BTCContext context { get; set; }
    }
