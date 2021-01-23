    public class UserRole
    {
        static List<UserRole> roles = new List<UserRole>();
        static UserRole()
        {
            foreach (/* SELECT * FROM UserRole */)
            {
                roles.Add(new UserRole(...));
            }
        }
        private UserRole(...){...}
        // Permissions that the role consists of.
        private bool CanEditEverything { get; private set; }
        // Use this whenever you need to display a list of UserRoles.
        public static ReadOnlyCollection<UserRole> AllUserRoles { get { return roles.AsReadOnly(); } }
        // If you still need to explicitly refer to a role by name, rather than 
        // its properties, do these and set them in the static constructor.
        public static UserRole SystemAdministrator { get; private set; }
    }
