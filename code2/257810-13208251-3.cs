    public class ProductViewModel
        {
            public Guid VmId { get; set; }
    
            [Required(ErrorMessage = "required")]
            public string ProductName { get; set; }
            
        }
