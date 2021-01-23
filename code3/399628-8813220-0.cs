    private void EncryptConfig()
    {
        // Open the Web.config file.
        Configuration config = 
            WebConfigurationManager.OpenWebConfiguration("~");
        // Get the connectionStrings section.
        ConnectionStringsSection section =
        config.GetSection("connectionStrings") as ConnectionStringsSection;
        // Toggle encryption.
        if (section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
        }
        else
        {
        if (!section.SectionInformation.IsLocked)
        {
            section.SectionInformation
                   .ProtectSection("RsaProtectedConfigurationProvider");             
            
            section.SectionInformation.ForceSave = true;             
            
            //Save changes to the Web.config file.       
            config.Save(ConfigurationSaveMode.Full);           }
        }
    }
