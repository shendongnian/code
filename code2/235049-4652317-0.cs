    public class IProductMetadata
    {         
        [HiddenInput(DisplayValue = false)]
        int ProductID;
    
        [Required(ErrorMessage = "Please enter a product name")]         
        string Name;
    
        [Required(ErrorMessage = "Please enter a description")]         
        string Description;
        // etc
    }
    [MetadataType(typeof(IProductMetadata))]
    public partial class Product
    {
    }
