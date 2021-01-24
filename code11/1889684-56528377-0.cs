cs
using System.DirectoryServices.AccountManagement;
public class ActiveDirectoryService {
    // The domain url is the url of the active directory server you're trying to validate with.
    public bool ValidateWithActiveDirectoryAsync(string domainUrl, string userName, string password) {
        using (var context = new PrincipalContext(ContextType.Domain, domainUrl)) {
            UserPrincipal UserPrincipal1 = new UserPrincipal(context);
            PrincipalSearcher search = new PrincipalSearcher(UserPrincipal1);
            if (context.ValidateCredentials(userName, password)) {
                return true;
            }
        }
        return false;
    }
}
I hope it works for you.
