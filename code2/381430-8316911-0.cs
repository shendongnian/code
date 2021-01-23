    public class Foo
    {
        public string Bar { get; set; }
    }
    
    class FooMetadata
    {
        [Display(Name = "Bar")]
        public string Bar { get; set; }
    }
    
    static void Main(string[] args)
    {
        AssociatedMetadataTypeTypeDescriptionProvider typeDescriptionProvider;
    
        typeDescriptionProvider = new AssociatedMetadataTypeTypeDescriptionProvider(
            typeof(Foo),
            typeof(FooMetadata));
    
        TypeDescriptor.AddProviderTransparent(typeDescriptionProvider, typeof(Foo));
    }
