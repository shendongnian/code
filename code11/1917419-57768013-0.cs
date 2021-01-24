    public class DataToSerialize 
    {     
        [JsonIgnore]
        public TData Data { get; set; }
        [JsonIgnore]
        public TData1 Data1 { get; set; }
        [JsonProperty("data")]
        public object SerializableData
        {
            get { return Data1 == null ? (object)Data : Data1; }
        }
     }
