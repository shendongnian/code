    [Table("emps", Schema = "dbo")]
    public class Emp
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Empno { get; set; }  
    }
