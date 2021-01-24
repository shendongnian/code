`
        public string GetManagersName(string emailAddress)
        {
            string userName = GetManagersUserNameByEmailAddress(emailAddress);
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, userName);
            string managersName = usr.GivenName;
            return managersName;
        }
        private string GetManagersUserNameByEmailAddress(string emailAddress)
        {
            DirectorySearcher adSearcher = new DirectorySearcher();
            adSearcher.Filter = ("mail=" + emailAddress);
            adSearcher.PropertiesToLoad.Add("samaccountname");
            SearchResult result = adSearcher.FindOne();
            DirectoryEntry user = result.GetDirectoryEntry();
            string userName = user.Properties["samaccountname"].Value.ToString();
            return userName;
        }
`
