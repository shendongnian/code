    [DataContract]
    public class TranslationData {
        [DataMember(Name = "sentences")]
        public Sentence[] Sentences { get; set; }
        [DataMember(Name = "src")]
        public string Source { get; set; }
        [DataMember(Name = "server_time")]
        public int ServerTime { get; set; }
    }
    
    [DataContract]
    public class Sentence {
        [DataMember(Name = "trans")]
        public string Translation { get; set; }
        [DataMember(Name = "orig")]
        public string Original { get; set; }
        [DataMember(Name = "translit")]
        public string Transliteration { get; set; }
        [DataMember(Name = "src_translit")]
        public string SourceTransliteration { get; set; }
    }
