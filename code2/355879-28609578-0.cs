    public bool IsGroupGroupMember(GroupPrincipal gp, GroupPrincipal pgp)
        {
            return gp.GetMembers(true).Contains(pgp);
        }
 
