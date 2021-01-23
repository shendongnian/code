    public override void Load()
    {
        Bind<ICommandModule>().ToMethod(
            c =>
                {
                    var sessionManager = c.Kernel<ISessionManager>();
                    if (!sessionManager.IsAuthenticated)
                        return c.Kernel.Get<VisitorCommandModule>();
                    var currentUser = sessionManager.CurrentUser;
                    if (currentUser.IsAdministrator)
                        return c.Kernel.Get<AdministratorCommandModule>();
                    if (currentUser.IsModerator)
                        return c.Kernel.Get<ModeratorCommandModule>();
                    return c.Kernel.Get<UserCommandModule>();
                }).InRequestScope();
    }
