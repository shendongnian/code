    [MetadataType(typeof(ICustomerMetaData))]
    public partial class Customer
    {
    }
    public interface ICustomerMetaData
    {
      // Apply RequiredAttribute
      [Required(ErrorMessage = "Title is required.")]
      string Title { get; }
    }
