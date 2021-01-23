    private void ProtectSection(String sSectionName)
    {
        // Open the app.config file.
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        // Get the section in the file.
        ConfigurationSection section = config.GetSection(sSectionName);
        // If the section exists and the section is not readonly, then protect the section.
        if (section != null)
        {
    	if (!section.IsReadOnly())
            {
    	    // Protect the section.
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                section.SectionInformation.ForceSave = true;
                // Save the change.
                config.Save(ConfigurationSaveMode.Modified);
             }
         }
    }
