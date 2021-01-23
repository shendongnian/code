    using System.DirectoryServices.AccountManagement;
    
    static void Main(string[] args)
    {
        ArrayList myGroups = GetUserGroups("My Local User");
    }
    public static ArrayList GetUserGroups(string sUserName)
    {
        ArrayList myItems = new ArrayList();
        UserPrincipal oUserPrincipal = GetUser(sUserName);
    
        PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetGroups();
    
        foreach (Principal oResult in oPrincipalSearchResult)
        {
            myItems.Add(oResult.Name);
        }
        return myItems;
    }
    
    public static UserPrincipal GetUser(string sUserName)
    {
        PrincipalContext oPrincipalContext = GetPrincipalContext();
    
        UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
        return oUserPrincipal;
    }
    public static PrincipalContext GetPrincipalContext()
    {
        PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Machine);
        return oPrincipalContext;
    }
