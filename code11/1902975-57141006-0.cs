        public class AppUser : IdentityUser<Guid>
        {
            // Add additional profile data for application users by adding properties to this class
            public string Name { get; set; }        
        }
