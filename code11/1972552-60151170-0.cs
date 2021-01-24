    public class Result
    {
        public string status { get; set; }
        public string message { get; set; }
    }
    
    public class Detail
    {
        [JsonProperty("RESOURCE DESCRIPTION")]
        public string ResourceDescription { get; set; }
        [JsonProperty("RESOURCE TYPE")]
        public string ResourceType { get; set; }
        [JsonProperty("RESOURCE ID")]
        public string ResourceId { get; set; }
        [JsonProperty("RESOURCE NAME")]
        public string ResourceName { get; set; }
        [JsonProperty("NOOFACCOUNTS")]
        public string NoOfAccounts { get; set; }
    }
    
    public class Operation
    {
        public string name { get; set; }
        public Result result { get; set; }
        public int totalRows { get; set; }
        public List<Detail> Details { get; set; }
    }
    
    public class RootObject
    {
        public Operation operation { get; set; }
    }
