    namespace BackEnd.Models
    {
        // Add IdentityRole
        public class UserContext: IdentityDbContext<IdentityUser,IdentityRole>
        {
            public UserContext()
            {
    
            }
          ...
    }
