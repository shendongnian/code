    public class OnlineDonationModel
    {
         [Required]
         public decimal? Amount { get; set; }
         public ContactModel Contact { get; set; }
    }
    public class ContactModel
    {
         [Required]
         public string FirstName { get; set; }
         [Required]
         public string LastName { get; set; }
         [Required]
         public string Address { get; set; }
         ...
    }
