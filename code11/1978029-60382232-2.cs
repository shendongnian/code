    using System.ComponentModel.DataAnnotations;
    namespace WebApplication1.Models
    {
    public class AddressModel
    {
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    }
