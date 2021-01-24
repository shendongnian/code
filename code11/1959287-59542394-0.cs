    [Table("MyTable")]
    public partial class MyTable
    {
        public Guid Id { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    
        // Navigation properties
        public virtual TypeA A { get; set; }
        public virtual TypeB B { get; set; }
        public virtual TypeC C { get; set; }
    }
