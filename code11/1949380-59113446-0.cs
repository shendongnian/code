    public partial class ServerList
    {
        public virtual ICollection<PockAdvCompany> Companies { get; set; }
        public virtual Server AwsServer { get; set; }
        [ForeignKey("AwsServer")]
        public int ServerId { get; set; }
    }
