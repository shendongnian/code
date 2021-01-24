c#
public static IEnumerable<string> GetPrimaryGroupMemberList(DirectoryEntry group) {
    group.RefreshCache(new[] { "distinguishedName", "primaryGroupToken" });
    
    var groupDn = (string) group.Properties["distinguishedName"].Value;
    var ds = new DirectorySearcher(
        new DirectoryEntry($"LDAP://{groupDn.Substring(groupDn.IndexOf("DC=", StringComparison.Ordinal))}"),
        $"(&(objectClass=user)(primaryGroupId={group.Properties["primaryGroupToken"].Value}))",
        new [] { "distinguishedName" })
    {
        PageSize = 1000
    };
    
    using (var primaryMembers = ds.FindAll()) {
        foreach (SearchResult primaryMember in primaryMembers) {
            yield return (string) primaryMember.Properties["distinguishedName"][0];
        }
    }
}
