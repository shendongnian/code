            public IList<string> FindUserGroupsLdap(string username)
        { 
            // setup credentials and connection  
            var credentials = new NetworkCredential("username", "password", "domain");  
            var ldapidentifier = new LdapDirectoryIdentifier("server", 389, true, false); 
            var ldapConn = new LdapConnection(ldapidentifier, credentials); 
            // retrieving the rootDomainNamingContext, this will make sure we query the absolute root   
            var getRootRequest = new SearchRequest(string.Empty, "objectClass=*", SearchScope.Base, "rootDomainNamingContext");  
            var rootResponse = (SearchResponse)ldapConn.SendRequest(getRootRequest);   
            var rootContext = rootResponse.Entries[0].Attributes["rootDomainNamingContext"][0].ToString();  
            // retrieve the user 
            string ldapFilter = string.Format("(&(objectCategory=person)(sAMAccountName={0}))", username); 
            var getUserRequest = new SearchRequest(rootContext, ldapFilter, SearchScope.Subtree, null);  
            var userResponse = (SearchResponse)ldapConn.SendRequest(getUserRequest);     
            // send a new request to retrieve the tokenGroups attribute, we can not do this with our previous request since 
            // tokenGroups needs SearchScope.Base (dont know why...)  
            var tokenRequest = new SearchRequest(userResponse.Entries[0].DistinguishedName, "(&(objectCategory=person))", SearchScope.Base, "tokenGroups");  
            var tokenResponse = (SearchResponse)ldapConn.SendRequest(tokenRequest);  
            var tokengroups = tokenResponse.Entries[0].Attributes["tokenGroups"].GetValues(typeof(byte[])); 
            // build query string this query will then look like (|(objectSid=sid)(objectSid=sid2)(objectSid=sid3))  
            // we need to convert the given bytes to a hexadecimal representation because thats the way they   
            // sit in ActiveDirectory  
            var sb = new StringBuilder();  
            sb.Append("(|");   
            for (int i = 0; i < tokengroups.Length; i++)  
            {  
                var arr = (byte[])tokengroups[i];    
                sb.AppendFormat("(objectSid={0})", BuildHexString(arr));   
            }   
            sb.Append(")");    
            // send the request with our build query. This will retrieve all groups with the given objectSid
            var groupsRequest = new SearchRequest(rootContext, sb.ToString(), SearchScope.Subtree, "sAMAccountName"); 
            var groupsResponse = (SearchResponse)ldapConn.SendRequest(groupsRequest); 
            // loop trough and get the sAMAccountName (normal, readable name)   
            var userMemberOfGroups = new List<string>();    
            foreach (SearchResultEntry entry in groupsResponse.Entries)    
            userMemberOfGroups.Add(entry.Attributes["sAMAccountName"][0].ToString());  
            return userMemberOfGroups;
        } 
        private string BuildHexString(byte[] bytes)
        {  
            var sb = new StringBuilder(); 
            for (int i = 0; i < bytes.Length; i++) 
            sb.AppendFormat("\\{0}", bytes[i].ToString("X2")); 
            return sb.ToString();
        }
