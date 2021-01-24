    public class Activity
    {
        public string Type { get; set; }
        public string AgentMACID { get; set; }
        // Optional: you can rename your property with this property attribute
        // [JsonProperty("INAgentMACID")]
        public string INAgentMACID { set { AgentMACID = value; } }
        // Optional: you can rename your property with this property attribute
        // [JsonProperty("OUTAgentMACID")]
        public string OUTAgentMACID { set { AgentMACID = value; } }
        public PlateNumber PlateNumber { get; set; }
    }
