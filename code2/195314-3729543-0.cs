    using (GroupPrincipal r = GroupPrincipal.FindByIdentity(context, "Remote Desktop Users"))
    using (GroupPrincipal u = GroupPrincipal.FindByIdentity(context, "Users"))
    {
        //snip
        UserPrincipal user = null;
        try
        {
            if (userInfo.NewPassword == null)
                throw new ArgumentNullException("userInfo.NewPassword", "userInfo.NewPassword was null");
            if (userInfo.NewPassword == "")
                throw new ArgumentOutOfRangeException("userInfo.NewPassword", "userInfo.NewPassword was empty");
            //If the user already is in the list of existing users use that one.
            if (pr.ContainsKey(username))
            {
                user = (UserPrincipal)pr[username];
                user.Enabled = true;
                user.SetPassword(userInfo.NewPassword);
            }
            else
            {
                //create new windows user.
                user = new UserPrincipal(context, username, userInfo.NewPassword, true);
                user.UserCannotChangePassword = true;
                user.PasswordNeverExpires = true;
                user.Save();
                r.Members.Add(user);
                r.Save();
                u.Members.Add(user);
                u.Save();
            }
            IADsTSUserEx iad = (IADsTSUserEx)((DirectoryEntry)user.GetUnderlyingObject()).NativeObject;
            iad.TerminalServicesInitialProgram = GenerateProgramString(infinityInfo);
            iad.TerminalServicesWorkDirectory = Service.Properties.Settings.Default.StartInPath;
            iad.ConnectClientDrivesAtLogon = 0;
            user.Save();              
        }
        catch(Exception e)
        {
           //snip
        }
        finally
        {
            if (user != null)
            {
                user.Dispose();
            }
        }
    }
