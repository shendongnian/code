    [System.Serializable]
    public class BTCBlock
    {
        public int id { get; set; }
        public string hash { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string median_time { get; set; }
        public int size { get; set; }
        public int stripped_size { get; set; }
        public int weight { get; set; }
        public int version { get; set; }
        public string version_hex { get; set; }
        public string version_bits { get; set; }
        public string merkle_root { get; set; }
        public long nonce { get; set; }
        public int bits { get; set; }
        public int difficulty { get; set; }
        public string chainwork { get; set; }
        public string coinbase_data_hex { get; set; }
        public int transaction_count { get; set; }
        public int witness_count { get; set; }
        public int input_count { get; set; }
        public int output_count { get; set; }
        public int input_total { get; set; }
        public int input_total_usd { get; set; }
        public long output_total { get; set; }
        public double output_total_usd { get; set; }
        public int fee_total { get; set; }
        public int fee_total_usd { get; set; }
        public int fee_per_kb { get; set; }
        public int fee_per_kb_usd { get; set; }
        public int fee_per_kwu { get; set; }
        public int fee_per_kwu_usd { get; set; }
        public int cdd_total { get; set; }
        public long generation { get; set; }
        public double generation_usd { get; set; }
        public long reward { get; set; }
        public double reward_usd { get; set; }
        public string guessed_miner { get; set; }
    }
    
    [System.Serializable]
    public class BTCDatum
    {
        public BTCBlock block { get; set; }
        public List<string> transactions { get; set; }
    }
    
    [System.Serializable]
    public class BTCCache
    {
        public bool live { get; set; }
        public int duration { get; set; }
        public string since { get; set; }
        public string until { get; set; }
        public object time { get; set; }
    }
    [System.Serializable]
    public class BTCApi
    {
        public string version { get; set; }
        public string last_major_update { get; set; }
        public object next_major_update { get; set; }
        public string tested_features { get; set; }
        public string documentation { get; set; }
        public string notice { get; set; }
    }
    [System.Serializable]
    public class BTCContext
    {
        public int code { get; set; }
        public string source { get; set; }
        public double time { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int results { get; set; }
        public int state { get; set; }
        public BTCCache cache { get; set; }
        public BTCApi api { get; set; }
    }
    [System.Serializable]
    public class BTCRootObject
    {   [JsonConverter(typeof(SingleValueArrayConverter<BTCDatum>))] 
        public List<BTCDatum> data { get; set; }
        public BTCContext context { get; set; }
    }
 
