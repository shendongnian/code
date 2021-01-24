    // Entity Framework Model
    public partial class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    // Your Interface with data annotations
    public interface IUser
    {
        [Required]
        string Email { get; set; }
        [Required]
        string Password { get; set; }
    }
    // Partial Model appling the interface to the entity model
    [MetadataType(typeof(IUser))]
    public partial class User : IUser
    {
    }
