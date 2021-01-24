    // using System.Security.Principal;
    // using System.DirectoryServices.AccountManagement;
    new PrincipalSearcher(new UserPrincipal(new PrincipalContext(ContextType.Machine)))
                    .FindAll()
                    .Single(a => a.Sid.IsWellKnown(WellKnownSidType.AccountGuestSid))
                    .Name // returns the local account name, e.g., 'Guest'
