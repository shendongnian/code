    public class User : IdentityUser 
    {
    
        public override string Id { get; set; }
    
        public virtual ICollection<UserVisitor> UserVisitors { get; set; }
        public virtual ICollection<UserVisitor> UserVisitors2 { get; set; }
    }
    public class UserVisitor 
    {
    
        public int Id { get; set; }
    
        [InverseProperty("User")]
        public string UserId { get; set; }
    
        public virtual User User {get; set;}
        public virtual User UserVisitor  {get; set;}
     
        [InverseProperty("User")]
        public string UserVisitorId { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime VisitTime { get; set; }
    
        public virtual User User { get; set; }
      }
