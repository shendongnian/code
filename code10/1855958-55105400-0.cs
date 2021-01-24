`
    [Table("ProcedureList")]
    public class Procedure
    {
        [Key]
        [Required]
        public int ProcedureId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }
