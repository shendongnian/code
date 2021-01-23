    namespace PasswordChanger
    {
        using System;
        using System.DirectoryServices.AccountManagement;
        class Program
        {
            static void Main(string[] args)
            {
                ChangePassword("domain", "user", "oldpassword", "newpassword");
            }
            public static void ChangePassword(string domain, string userName, string oldPassword, string newPassword)
            {
                try
                {
                    using (var context = new PrincipalContext(ContextType.Domain, domain))
                    using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName))
                    {
                        user.ChangePassword(oldPassword, newPassword);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
