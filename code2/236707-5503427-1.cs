    [DataContract]
    public class RpcRequest<T>
    {
        [JsonProperty("id")]
        [DataMember(Name="id")]
        public String Id { get; set; }
    
        [JsonProperty("method")]
        [DataMember(Name="method")]
        public String Method { get; set; }
    
        [JsonProperty("params")]
        [DataMember(Name="params")]
        public T Params { get; set; }
    
        [JsonIgnore]
        [IgnoreDataMember]
        public Policy Policy { get; set; }
    }
