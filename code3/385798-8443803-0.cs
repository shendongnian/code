    [Table("Foo")]
    public class Foo {
        [Key]
        public Int32 FooId { get; set; }
        public String FooName { get; set; }
        [InverseAttribute("Foos")]
        public ICollection<Bar> Bars { get; set; }
    }
    
    [Table("Bar")]
    public class Bar { 
        [Key]
        public Int32 BarId { get; set; }
        public String BarName { get; set; }
        [InverseAttribute("Bars")]
        public ICollection<Foo> Foos { get; set; }
    }
