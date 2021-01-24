    public class EntityEnviroment
    {
        [Key]
        public virtual int env_id { get; set; }
        public virtual string env_name { get; set; }
        public virtual string env_country { get; set; }
        public virtual ICollection<StcEntityFailedReportDetail> failedReportDetails { get; set; } = new List<StcEntityFailedReportDetail>();
    }
