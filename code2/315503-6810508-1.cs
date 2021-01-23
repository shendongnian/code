    public List<ADGroup> GetMemberGroups(string loginId, PrincipalContext principalContext, int tries = 0)
    {
    var result = new List<ADGroup>();
    bool Done = false;
    try
    {
        var samAccountName = "";
        if (loginId.Contains(" "))
        {
            var fName = loginId.Split(Char.Parse(" "))[0].ToLower();
            var sName = loginId.Split(Char.Parse(" "))[1].ToLower();
            if (sName.Trim().Length == 2)
                samAccountName = string.Format("{0}{1}", fName.StartsWith(".") ? fName.Substring(0, 4) : fName.Substring(0, 3), sName.Substring(0, 2));
            else
                samAccountName = string.Format("{0}{1}", fName.StartsWith(".") ? fName.Substring(0, 3) : fName.Substring(0, 2), sName.Substring(0, 3));
        }
        else
            samAccountName = loginId.Substring(loginId.IndexOf(@"\") + 1);
        var authPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, samAccountName);
        if (authPrincipal == null)
            throw new Exception(string.Format("authPrincipal is null for loginId - {0}", loginId));
        var firstLevelGroups = authPrincipal.GetGroups();
        AddGroups(firstLevelGroups, ref result);
        Done = true;
    }
    catch
    {
        if (tries > 5)
            throw;
        tries += 1;
    }
    if ( ( !Done) && (tries < 6) )
         {
         System.Threading.Thread.Sleep(1000);
         result = GetMemberGroups(loginId, principalContext, tries);
         }
    return result;
    }
    private void AddGroups(PrincipalSearchResult<Principal> principal, ref List<ADGroup> returnList)
    {
        if ( principal == null )
             return;
        foreach (var item in principal)
        {
            if (item.GetGroups().Count() > 0)
                AddGroups(item.GetGroups(), ref returnList);
            returnList.Add(new ADGroup(item.SamAccountName, item.Sid.Value));
        }
    }
