        public bool Validate(string username, string password)
        {
            
            //ex PrincipalContext principalContext = new PrincipalContext(ContextType.ApplicationDirectory,"sea-dc-02.fabrikam.com:50001","ou=ADAM Users,o=microsoft,c=us",ContextOptions.SecureSocketLayer | ContextOptions.SimpleBind,"CN=administrator,OU=ADAM Users,O=Microsoft,C=US","P@55w0rd0987");
 
            try
            {
                using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, Configuration.Config.ActiveDirectory.PrimaryServer, Configuration.Config.ActiveDirectory.Container, ContextOptions.Negotiate))
                {
                    return principalContext.ValidateCredentials(username, password);
                }
            }
            catch (PrincipalServerDownException)
            {
                Debug.WriteLine("PrimaryServer={0};Container={1}", Configuration.Config.ActiveDirectory.PrimaryServer, Configuration.Config.ActiveDirectory.Container);
                Debug.WriteLine("LDAP://{0}/{1}", Configuration.Config.ActiveDirectory.PrimaryServer, Configuration.Config.ActiveDirectory.Container);
                throw;
            }
