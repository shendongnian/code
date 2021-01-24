public void SaveUser(SearchRolesViewModel objSearchRolesViewModel, string userID)
        {
           DirectoryEntry de = new DirectoryEntry();
                de = QueryAD(objSearchRolesViewModel.NID); // <--- This is the issue.
...
Look up DirectoryEntry from the QueryAD function and return that object to make your call work.
public string QueryAD(string userNID) // You will need to return DirectoryEntry to make your code work.
        {
            DirectorySearcher ds = new DirectorySearcher
EDIT:
I find using UserPrincipal with PrincipalContext to be much simpler. Look up PrincipalContext by using your domain name and provide creds if not running with domain account. Then, simply, lookup user by SamAccountName, Name/ID or DistinguishedName.
You will need, ```'System.DirectoryServices.AccountManagement'``` nuget package for Principal usage.
public static UserPrincipal QueryAD(string UserName)
    {
        PrincipalContext context = new PrincipalContext(ContextType.Domain, "Aeth", "user", "password");
        // Without creds if the account running the code is already a domain account
        //PrincipalContext context = new PrincipalContext(ContextType.Domain, "Aeth"); 
        // You can search the account by SamAccountName, DistinguishedName, UserPrincipalName or SID
        return UserPrincipal.FindByIdentity(context, IdentityType.Name, UserName);
            
    }
    public void SaveUser(SearchRolesViewModel objSearchRolesViewModel, string userID)
    {
        UserPrincipal user = QueryAD(objSearchRolesViewModel.User_Id);
        USERACCOUNT objUserAccount = new USERACCOUNT
        {
            HPID = Convert.ToInt32(objSearchRolesViewModel.NewUserHealthPlans),
            DOMAIN = "Aeth",
            NTUSERID = objSearchRolesViewModel.User_Id,
            ROLEID = Convert.ToInt32(objSearchRolesViewModel.UserRole),
            FIRSTNAME = user.GivenName, // Get FirstName
            LASTNAME = user.Surname,    // Get LastName
            EMAIL = user.EmailAddress,  // Get Email Address
            ACTIVE =  user.Enabled,     // Get User Status
            DEFAULTPLANID = Convert.ToInt32(objSearchRolesViewModel.NewUserPrimaryHealthPlan),
            CREATEID = userID,
            CREATEDATE = DateTime.Now,
            UPDATEID = userID,
            UPDATEDATE = DateTime.Now
        };
        _context.USERACCOUNTs.Add(objUserAccount);
        _context.SaveChanges();
    }
