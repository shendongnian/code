    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Userid { get; set; }
        [Required]
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Middlename { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public DateTime? Createddate { get; set; }
    }
