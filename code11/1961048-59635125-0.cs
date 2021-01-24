cs
using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "my.domain.net", ou))
using (GroupPrincipal GroupPrin = new GroupPrincipal(context))
using (var searcher = new PrincipalSearcher(GroupPrin))
using (var results = searcher.FindAll())
{
    foreach (GroupPrincipal result in results)
    {
        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
        string GUID = de.Guid.ToString();
        string testname1 = de.Name;
        string testParentName1 = de.Parent.Name;
        string MasterGroupname = testname1.Substring(3, (testname1.Length - 3));
        string type = testParentName1.Substring(3, (testParentName1.Length - 3));
        using (var users = result.GetMembers(true))
        {
            foreach (Principal user in users)
            {
                DataRow dr1 = resultsTable.NewRow();
                dr1["EmailID"] = user.UserPrincipalName;
                dr1["UserID"] = user.SamAccountName;
                dr1["memberOf"] = MasterGroupname;
                dr1["groupType"] = type;
                dr1["record_date"] = RecordDate;
                resultsTable.Rows.Add(dr1);
                user.Dispose();
            }
        }
        result.Dispose();
    }
}
This will probably work, but could probably still be much faster. Using `Principal` objects (and the whole `AccountManagement` namespace) is a wrapper around `DirectoryEntry`/`DirectorySearcher` which makes things somewhat easier for you, but at the cost of performance. Using `DirectoryEntry`/`DirectorySearcher` directly is *always* faster.
If you want to experiment with that, I wrote a couple articles that will help:
- [Active Directory: Better performance](https://www.gabescode.com/active-directory/2018/12/15/better-performance-activedirectory.html)
- [Active Directory: Find all the members of a group](https://www.gabescode.com/active-directory/2018/11/30/find-all-members-of-group.html)
