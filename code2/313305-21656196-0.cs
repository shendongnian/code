    public class MyModelBase
    {
        public virtual string Name { get; set; }
    }
    
    public class MyModel : MyModelBase
    {
        [Required]
        public override string Name { get { return base.Name; } set { base.Name = value; }
    
        public string SomeOtherProperty { get; set; }
    }
