       public class ApplicationUser : IdentityUser<Guid>
        {
            [MaxLength(64)]
            public string FirstName { get; set; }
        
            [MaxLength(64)]
            public string LastName { get; set; }
        
            public ICollection<ApiLogItem> ApiLogItems { get; set; }
        }
 
    public class ApiLogItem
        {
            [Key]
            public long Id { get; set; }
        
            [Required]
            public int StatusCode { get; set; }
        
            [Required]
            public string Method { get; set; }
        
            [MaxLength(45)]
            public string IPAddress { get; set; }
        
            public Guid? UserId { get; set; }
        }
    
        
