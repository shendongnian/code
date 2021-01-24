    [DataContract]
    public class ConsoDataPhaseParams : CommonParams
    {
        [DataMember]
        public List<string> ListPhases { get; set; }
        [DataMember]
        public List<string> ListPerimetres { get; set; }
        [DataMember]
        public List<string> ListVariants { get; set; }
        [DataMember]
        public List<string> ListCurrencies { get; set; }
    }
