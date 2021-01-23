       // Simply by using UserPrincipal
       // Include the namespace - System.DirectoryServices
       using DS = System.DirectoryServices;
       string CurrUsrEMail = string.Empty;
       CurrUsrEMail = DS.AccountManagement.UserPrincipal.Current.EmailAddress;
