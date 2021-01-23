    [MetadataType(typeof(FooMetadata))]
    public partial class Foo {}
    public class FooMetadata
    {
        //apply validation attributes to properties
        [Required]
        [Range(0, 25)]
        [DisplayName("Some Neato Property")]
        public int SomeProperty { get; set; }
    }
    
