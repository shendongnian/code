    [Table("Permissions")]
    public class Permissions
    {
        [Key]
        [MaxLength(255)] // <---
        public String EmployeeName { get; set; }
    }
