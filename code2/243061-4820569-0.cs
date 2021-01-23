    [DataContract]
    internal class Folder
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMemberAttribute(Name = "subfolder")]
        public List<SubFolder> SubFolder { get; set; }
    }
    [DataContractAttribute(Name = "subfolder")]
    internal class SubFolder
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "document")]
        public List<string> Document { get; set; }
    }
