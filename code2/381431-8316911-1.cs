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
        PropertyDescriptorCollection properties;
    
        AssociatedMetadataTypeTypeDescriptionProvider typeDescriptionProvider;
    
        properties = TypeDescriptor.GetProperties(typeof(Foo));
        Console.WriteLine(properties[0].Attributes.Count); // Prints X
    
        typeDescriptionProvider = new AssociatedMetadataTypeTypeDescriptionProvider(
            typeof(Foo),
            typeof(FooMetadata));
    
        TypeDescriptor.AddProviderTransparent(typeDescriptionProvider, typeof(Foo));
    
        properties = TypeDescriptor.GetProperties(typeof(Foo));
        Console.WriteLine(properties[0].Attributes.Count); // Prints X+1
    }
