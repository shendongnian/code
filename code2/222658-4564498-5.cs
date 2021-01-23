        public MvcApplication()
        {
            AuthenticateRequest += OnAuthenticateRequest;
        }
        private void OnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var allRoles = CompositeRoleSet.CreateDefault();
            var roles = allRoles.Resolve(Role.ReadWrite);
            Context.User = new ApplicationUser(roles);
        }
