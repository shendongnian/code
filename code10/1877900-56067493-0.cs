    public class User
    {
        public string UserPrincipalName { get; set; }
        public string Name { get; set; }
    }
    User GetAdUser(string domain, string userName)
    {
        string ldapBase = string.Format("LDAP://{0}", domain);
        using (var entry = new DirectoryEntry(ldapBase))
        {
            using (var searcher = new DirectorySearcher(entry))
            {
                searcher.Filter = string.Format("(sAMAccountName={0})", userName);
                var result = searcher.FindOne();
                User user = null;
                if (result != null)
                {
                    // result.Properties - list of loaded user properties
                    // result.Properties.PropertyNames - list of user property names                
                    user = new User
                    {
                        UserPrincipalName = result.Properties["userprincipalname"].Cast<string>().FirstOrDefault();
                        Name = result.Properties["name"].Cast<string>().FirstOrDefault();
                    }
                }
                
                return user;
            }
        }
    }
 
