    public class ApplicationUser : IdentityUser
        {
            public ApplicationUser()
            {
                CreatedOn = DateTime.Now;
                LastPassUpdate = DateTime.Now;
                LastLogin = DateTime.Now;
            }
            public String FirstName { get; set; }
            public String MiddleName { get; set; }
            public String LastName { get; set; }
            public String EmailId { get; set; }
            public String ContactNo { get; set; }
            public String HintQuestion { get; set; }
            public String HintAnswer { get; set; }
            public Boolean IsUserActive { get; set; }
            
            //Auditing Fields
            public DateTime CreatedOn { get; set; }
            public DateTime LastPassUpdate { get; set; }
            public DateTime LastLogin { get; set; }
        }
