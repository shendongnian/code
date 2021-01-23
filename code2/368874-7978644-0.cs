    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        // it's possible to add logic and non-mapped properties here
    }
    
    
    public class CustomerMetadata
    {
        [Required(ErrorMessage="Name is required")] 
        public object Name { get; set; }   // note the 'object' type
    }
