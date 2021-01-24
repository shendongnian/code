        public class LdapAuthenticationService : IAuthenticationService
        {
            public bool ValidateUser(string domainName, string username, string password)
            {
                string userDn = $"{username}@{domainName}";
                try
                {
                    using (var connection = new LdapConnection { SecureSocketLayer = false })
                    {
                        connection.Connect(domainName, LdapConnection.DefaultPort);
                        connection.Bind(userDn, password);
                        if (connection.Bound)
                            return true;
                    }
                }
                catch (LdapException ex)
                {
                    // Log exception
                }
                return false;
            }        
        }
        public interface IAuthenticationService
        {
            bool ValidateUser(string domainName, string username, string password);
        }
