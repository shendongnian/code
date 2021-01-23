    public abstract class AuditableTable : TableServiceEntity, IAuditableTable  
    {
        protected AuditableTable()
            : base()
        {
            Status = "3";
        }
        public string Status { get; set; }
    }
