    public abstract class Entity
    {
        [Browsable(false)]
        public int CreatedBy { get; set; }
        [DisplayName("Utworzył")]
        public string CreatedByName { get; set; }
        [DisplayName("Data utworzenia")]
        public DateTime CreatedOn { get; set; }
        [Browsable(false)]
        public int? LmBy { get; set; }
        [DisplayName("Zmodyfikował")]
        public string LmByName { get; set; }
        [DisplayName("Data modyfikacji")]
        public DateTime? LmOn { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        public abstract int Id { get; set; }
    }
    
    
