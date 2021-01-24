    public class BasicList
    {
        ...
        [JsonProperty("private")]
        private string PrivateAsString { get; set; }
        [JsonIgnore]
        public bool Private
        {
            get { return PrivateAsString != "0"; }
            set { PrivateAsString = value ? "1" : "0"; }
        }
        ...
    }
