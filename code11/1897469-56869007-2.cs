    public class IdentityProfile 
    {
       [Required]
       [ForeignKey("Profile")]
       public System.Guid ProfileId { get; set; }
    
       public virtual UserProfile Profile { get; set; }
    }
    
    public class UserProfile 
    {
        [InverseProperty("Profile")]
        public virtual ICollection<IdentityProfile> IdentityProfiles { get; set; }
    }
