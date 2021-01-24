    [Table("Permissions")]
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] <--
        [MaxLength(255)] // <---
        public String EmployeeName { get; set; }
    }
