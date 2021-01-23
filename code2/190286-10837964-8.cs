    public class AppUser
    {
        public int Id { get; set; }
            
        public string Username { get; set; }
        
        public OpenIdInfo OpenIdInfo { get; set; }
    }
                
    ​public class OpenIdInfo
    {
        [ForeignKey("AppUser")]
        public int Id { get; set; }
            
        public string OpenId { get; set; }
            
        public AppUser AppUser { get; set; }
    }
