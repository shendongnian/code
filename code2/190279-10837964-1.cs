    using System.ComponentModel.DataAnnotations;
    [Table("AppUser")]
    public class AppUser
    {
        public int Id { get; set; }
            
        public string Username { get; set; }
        
        public OpenIdInfo OpenIdInfo { get; set; }
    }
    
    [Table("AdminUser")]      
    public class AdminUser : AppUser
    {
        public bool SuperAdmin { get; set; }
    }
​
