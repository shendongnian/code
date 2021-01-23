    [OperationBehavior(Impersonation=ImpersonationOption.NotAllowed)]
    public string SetPassword(string username)
    {
        WindowsPrincipal principal = new WindowsPrincipal(OperationContext.Current.ServiceSecurityContext.WindowsIdentity);
        if (principal.IsInRole("WCFUsers"))
        {
            try
            {
                lock (Watchdog.m_principalContext)
                {
                    using (UserPrincipal up = UserPrincipal.FindByIdentity(Watchdog.m_principalContext, username))
                    {
                        string newpassword = CreateRandomPassword();
                        up.SetPassword(newpassword);
                        up.Save();
                        return newpassword;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        else
            return null;
    }
