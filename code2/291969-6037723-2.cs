    public class CommandModuleProvider : IProvider
    {
        public Type Type { get { return typeof(ICommandModule); } }
        public object Create(IContext context)
        {
            var securityInfo = context.Kernel.Get<SecurityInformation>();
            if (securityInfo.IsAuthenticated)
                if (securityInfo.IsCurrentUserAdministrator)
                    //load administrator command module
                    return context.Kernel.Get<AdministratorCommandModule>();
                else if (securityInfo.IsCurrentUserModerator)
                    //Load moderator command module
                    return context.Kernel.Get<ModeratorCommandModule>();
                else
                    //Load user command module
                    return context.Kernel.Get<UserCommandModule>();
            else
                //Load visitor command module
                return context.Kernel.Get<VisitorCommandModule>();
         }
    }   
