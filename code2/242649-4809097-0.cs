    [DataContract]
    public class iTunesResult
    {
        [DataMember]
        public iTuneJsonResults[] results { get; set; }
    }
    [DataContract]
    public class iTuneJsonResults
    {
        [DataMember]
        public string artistName { get; set; }
    }
