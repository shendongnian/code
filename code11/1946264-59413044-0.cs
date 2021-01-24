    public class ApplicationUser : IdentityUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
    
    var user = new ApplicationUser
    {
        Id = "CustomId",
        UserName = "user",
        Email = "user@email.com"
    }
