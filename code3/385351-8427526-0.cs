    [DataContract]
    public class PCState // need a better name
    {
        [DataMember]
        public PCIdentifier Identifier {get;set;}
        [DataMember]
        public List<FilesWithSettings> Files {get;set;}
    }
