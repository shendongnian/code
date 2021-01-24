    [Table("MyObject", Schema = "myschema")]
    public class MyObject
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	[Key]
        public Guid Id { get; set; }
        public String Field1 { get; set; }
        public String Field2 { get; set; }
    }
