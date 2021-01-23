    public class Foo
    {
        public string FooId { get; set; }
    
        public Boo Boo { get; set; }
    }
    public class Boo
    {
        public string BooId { get; set; }
        
        [Required]
        public Foo Foo {get; set; }
    }
