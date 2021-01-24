    public class Staff : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
    }
