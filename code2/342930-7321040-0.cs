    public class ProductAddModel
    {
      [Required]
      [StringLength(10)]
      public string ProductCode { get; set; }
    
      [Required]
      [StringLength(40)]
      public string ProductName { get; set; }
    }
