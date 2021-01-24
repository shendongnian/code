    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUserRole() : base()
        {
        }
        public virtual string UserId { get; set; }
        
        public virtual string RoleId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
