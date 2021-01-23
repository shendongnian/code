    class MyModelMetadata
    {
        [Required]
        public string Name { get; set; }
 
        public string SomeOtherProperty { get; set; }
    }
    [MetadataType(typeof(MyModelMetadata)]
    public class MyModel : MyModelBase
    {
        public string SomeOtherProperty { get; set; }
    }
