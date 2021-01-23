    public bool IsUserMemberOfGroup(string groupName)
        {
            // CN is your distro group name. OU is the object(s) in your AD hierarchy. DC is for your domain and domain suffix (e.g., yourDomain.local)
            string searchFilter = String.Format(@"(&(objectcategory=user)(sAMAccountName=markp)(memberof=CN={0},OU=System Admins,OU=USA,DC=yourDomain,DC=local))", groupName);
            SearchResultCollection searchResult;
    
            using (var dirEntry = new DirectoryEntry("LDAP://dc=yourDomain,dc=local"))
            {
                using (var dirSearch = new DirectorySearcher(dirEntry))
                {
                    dirSearch.SearchScope = SearchScope.Subtree;
                    dirSearch.Filter = searchFilter;
                    searchResult = dirSearch.FindAll();
                }
            }
            if (searchResult.Count <= 0 || searchResult == null) {
                return false; // not in group
            }
            else {
                return true; // in group
            }
        }
