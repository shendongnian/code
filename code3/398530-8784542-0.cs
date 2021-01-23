    public class Foo
    {
        [Required]
        public int? RequiredScalarId { get; set; }
        public virtual Bar RequiredNavigationalProp { get; set; }
    }
