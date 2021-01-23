    public bool IsGroupGroupMember(GroupPrincipal gp, GroupPrincipal pgp)
            {
                PrincipalSearchResult<Principal> result = gp.GetGroups();
                Principal grp = result.Where(g => g.Sid == pgp.Sid).FirstOrDefault();
    
                if (grp == null)
                {
                    return false; 
                }
                else
                {
                    return true; 
                }
    }
