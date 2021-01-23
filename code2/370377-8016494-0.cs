    IsUserGroupMember("username", "group name the user is in");
    
    public string sDomain = "your.domainName.com"
    public string sDefaultOU = OU=**,OU=**,DC=**,DC=**,DC=**
    
            public void IsUserGroupMember(string sUserName, string sGroupName)
            {
                try
                {
                    UserPrincipal oUserPrincipal = GetUser(sUserName);
                    GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
    
                    if (oUserPrincipal != null && oGroupPrincipal != null)
                    {
                        //do something
                    }
                    else
                    {
                        //nothing
                    }
                }
                catch (PrincipalServerDownException)
                {
                    throw;
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
    
    public UserPrincipal GetUser(String sUserName)
            {
                PrincipalContext oPrincipalContext = GetPrincipalContext();
    
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
                return oUserPrincipal;
    
    
            }
    
            public GroupPrincipal GetGroup(string sGroupName)
            {
                PrincipalContext oPrincipalContext = GetPrincipalContext();
    
                GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
                return oGroupPrincipal;
            }
    
            public PrincipalContext GetPrincipalContext()
            {
                PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sDefaultOU, ContextOptions.Negotiate);
                return oPrincipalContext;
            }
