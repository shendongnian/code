        public void Createuser(string username)
        {
           
            if (DomainExists(ConnectionString))
            {
                var baseDirectory = new DirectoryEntry(ConnectionString);
                DirectoryEntry user = baseDirectory.Children.Add("CN=" + username, "user");
                user.Properties["sAMAccountName"].Add(username);
                user.CommitChanges();
            }
        }
