    // ActiveDirectoryUserRepository.cs
    public class ActiveDirectoryUserRepository
    {
        public User FindUserByName(string name)
        {
             DirectorySearcher searcher = new DirectorySearcher();
             // ...
             // set up the filter and properties of the searcher
             // ...
             Result result = searcher.FindOne();
             User user = new ProxyUser(this)
             {
                 Name = result.Properties["displayName"][0],
                 Email = result.Properties["email"][0],
                 GroupNames = new List<string>()
             };
            
             foreach(string groupName in result.Properties["memberOf"])
             {
                 user.GroupNames.Add(groupName);
             }
             return user;
        }
        public Group FindGroupByName(string name)
        {
            // Find the Group, which should be similar to FindUserByName
        }
    }
    
