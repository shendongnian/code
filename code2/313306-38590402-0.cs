    public class MyModelBase
    {
         public string Name { get; set; }
    }
    public class MyModel : MyModelBase
    {
         [Required]
         public new string Name {get; set;}
         public string SomeOtherProperty { get; set; }
    }
