 lang-cs
DirectoryEntry ADEntry()
{
    using (DirectoryEntry ADEntry = new DirectoryEntry(myDomain, myAdminServiceUsername, myAdminServicePassword, AuthenticationTypes.Secure))
    {
        return ADEntry;
    }
}
DirectorySearcher ADSearcher()
{
    using(DirectorySearcher ADSearcher = new DirectorySearcher(ADEntry()))
    {
        return ADSearcher;
    }
}
So this:
 lang-cs
...
DirectorySearcher ADS = ADSearcher();
ADS.Filter = "(&(objectClass=user)(sAMAccountname=" + userToFind + "))";
searchResult = ADS.FindOne();
...
...can effectively be translated to this:
 lang-cs
var directoryEntry = new DirectoryEntry(myDomain, myAdminServiceUsername, myAdminServicePassword, AuthenticationTypes.Secure);
directoryEntry.Dispose();
var directorySearcher = = new DirectorySearcher(directoryEntry);
directorySearcher.Dispose();
directorySearcher.Filter = "(&(objectClass=user)(sAMAccountname=" + userToFind + "))";
var searchResult = directorySearcher.FindOne();
Unfortunately, I don't have an AD available to test against, and it's possible that this isn't the root cause of your issue. However, I would recommend fixing the code to not use object instances after they have been disposed. The following might be a better approach:
 lang-cs
SearchResult searchResult;
using (var directoryEntry = new DirectoryEntry(myDomain, myAdminServiceUsername, myAdminServicePassword, AuthenticationTypes.Secure))
using (var directorySearcher = new DirectorySearcher(directoryEntry))
{
    directorySearcher.Filter = "(&(objectClass=user)(sAMAccountname=" + userToFind + "))";
    searchResult = directorySearcher.FindOne();
}
// It's OK to use searchResult here, it's not `IDisposable`.
