    public class UserLogin : IdentityUser
    {       
        public int LanguageId { get; set; }
        public string HQ_PRM_Id { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }            
    }
