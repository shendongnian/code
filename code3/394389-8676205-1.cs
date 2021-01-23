    public abstract class AuditableTable : TableServiceEntity, IAuditableTable  
    {
        protected AuditableTable()
            : base()
        {
            InitFields();
        }
        protected AuditableTable(string pk, string rk)
            : base(pk, rk) 
        { 
            InitFields();
        }
        private InitFields()
        {
            Status = "3";
        }
        public string Status { get; set; }
    }
