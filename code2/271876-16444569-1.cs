    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using ActiveDs;
    //...
    PrincipalContext domain = new PrincipalContext(ContextType.Domain);
    UserPrincipal user = UserPrincipal.FindByIdentity(domain, "username");
    DirectoryEntry entry = (DirectoryEntry)user.GetUnderlyingObject();
    IADsUser native = (IADsUser)entry.NativeObject;
    Console.WriteLine(user.GivenName + "'s password will expire on " + native.PasswordExpirationDate);
