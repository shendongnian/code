    class User : IPrincipal
    {
        private readonly bool IsAdmin;
        // or better
        private readonly string[] roles; // or HashSet<string> to speed up lookup
    
        public User(string name)
        {
            // fetch and fill from db
        }
    
        bool IPrincipal.IsInRole(string role)
        {
            return role == "admin" && this.IsAdmin;
            // or better
            return this.roles.Contains(role);
        }
    }
