    public class UnitOfMeasure : PasBase, IAudit
    {
        [Key]
        public long UnitOfMeasureId { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string Memo { get; set; }
        public string Standard { get; set; }
        public Int32 MasterCompanyId { get; set; }
        [ForeignKey("MasterCompanyId")]
        public MasterCompany MasterCompany { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public string UploadStatus { get; set; }
    }
