    public class SomeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? SomeEntityID { get; set; }
    }
