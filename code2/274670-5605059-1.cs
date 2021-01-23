    using System.Configuration;
    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    AppSettingsSection configSection = config.AppSettings;
    try {
      if (configSection != null) {
        if (configSection.IsReadOnly() == false && configSection.SectionInformation.IsLocked == false) {
          configSection.Settings("KeyName").Value = "NewValue";
        config.Save();
        }
      }
    }   
    catch (ConfigurationException ex) {
       MessageBox.Show(ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
