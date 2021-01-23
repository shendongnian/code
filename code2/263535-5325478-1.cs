     public void saveIdentity(string username, string password, bool impersonate)
        {
            Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
            IdentitySection identitySection = (IdentitySection)objConfig.GetSection("system.web/identity");
            if (identitySection != null)
            {
                identitySection.UserName = username;
                identitySection.Password = password;
                identitySection.Impersonate = impersonate;
            }
        objConfig.Save();
    }
