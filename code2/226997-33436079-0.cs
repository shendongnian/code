        public List<String> GetUserGroups(WindowsIdentity identity)
        {
            List<String> groups = new List<String>();
            String userName = identity.Name;
            int pos = userName.IndexOf(@"\");
            if (pos > 0) userName = userName.Substring(pos + 1);
            PrincipalContext domain = new PrincipalContext(ContextType.Domain, "riomc.com");
            UserPrincipal user = UserPrincipal.FindByIdentity(domain, IdentityType.SamAccountName, userName); // NGeodakov
            DirectoryEntry de = new DirectoryEntry("LDAP://RIOMC.com");
            DirectorySearcher search = new DirectorySearcher(de);
            search.Filter = "(&(objectClass=group)(member=" + user.DistinguishedName + "))";
            search.PropertiesToLoad.Add("cn");
            search.PropertiesToLoad.Add("samaccountname");
            search.PropertiesToLoad.Add("memberOf");
            SearchResultCollection results = search.FindAll();
            foreach (SearchResult sr in results)
            {
                GetUserGroupsRecursive(groups, sr, de);
            }
            return groups;
        }
        public void GetUserGroupsRecursive(List<String> groups, SearchResult sr, DirectoryEntry de)
        {
            if (sr == null) return;
            String group = (String)sr.Properties["cn"][0];
            if (String.IsNullOrEmpty(group))
            {
                group = (String)sr.Properties["samaccountname"][0];
            }
            if (!groups.Contains(group))
            {
                groups.Add(group);
            }
            DirectorySearcher search;
            SearchResult sr1;
            String name;
            int equalsIndex, commaIndex;
            foreach (String dn in sr.Properties["memberof"])
            {
                equalsIndex = dn.IndexOf("=", 1);
                if (equalsIndex > 0)
                {
                    commaIndex = dn.IndexOf(",", equalsIndex + 1);
                    name = dn.Substring(equalsIndex + 1, commaIndex - equalsIndex - 1);
                    search = new DirectorySearcher(de);
                    search.Filter = "(&(objectClass=group)(|(cn=" + name + ")(samaccountname=" + name + ")))";
                    search.PropertiesToLoad.Add("cn");
                    search.PropertiesToLoad.Add("samaccountname");
                    search.PropertiesToLoad.Add("memberOf");
                    sr1 = search.FindOne();
                    GetUserGroupsRecursive(groups, sr1, de);
                }
            }
        }
