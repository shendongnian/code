    if (ServiceSecurityContext.Current.WindowsIdentity.ImpersonationLevel == TokenImpersonationLevel.Impersonation ||
        ServiceSecurityContext.Current.WindowsIdentity.ImpersonationLevel == TokenImpersonationLevel.Delegation)
    {
        using (ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
        {
            Console.WriteLine("Impersonating the caller imperatively");
            Console.WriteLine("\t\tThread Identity            :{0}",
        WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("\t\tThread Identity level  :{0}",
                 WindowsIdentity.GetCurrent().ImpersonationLevel);
            Console.WriteLine("\t\thToken                     :{0}",
                 WindowsIdentity.GetCurrent().Token.ToString());
        }
    }
