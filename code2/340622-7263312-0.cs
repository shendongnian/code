    public class RegionalInfo
    {
        [Key]
        public String ContentId { get; set; }
        public virtual Content Content { get; set; }
        [Key]
        public string RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
