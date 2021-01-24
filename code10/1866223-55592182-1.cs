          private string GetEmail(IIdentity id)
        {
            System.DirectoryServices.ActiveDirectory.Domain domain = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain();
            string address = String.Empty;
            using (HostingEnvironment.Impersonate())
            {
                using (var context = new PrincipalContext(ContextType.Domain, domain.Name, null, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer))
                using (var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, id.Name))
                {
                    address = userPrincipal.EmailAddress;
                }
            }
            return address;
        }
