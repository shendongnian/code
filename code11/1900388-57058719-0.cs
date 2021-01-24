    private static string GetUserPrimaryGroup(DirectoryEntry de) {
        de.RefreshCache(new[] {"primaryGroupID", "objectSid"});
    
        //Get the user's SID as a string
        var sid = new SecurityIdentifier((byte[])de.Properties["objectSid"].Value, 0).ToString();
    
        //Replace the RID portion of the user's SID with the primaryGroupId
        //so we're left with the group's SID
        sid = sid.Remove(sid.LastIndexOf("-", StringComparison.Ordinal) + 1);
        sid = sid + de.Properties["primaryGroupId"].Value;
    
        //Find the group by its SID
        var group = new DirectoryEntry($"LDAP://<SID={sid}>");
        group.RefreshCache(new [] {"cn"});
    
        return group.Properties["cn"].Value as string;
    }
