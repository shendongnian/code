    /// <summary>
    /// Loads own config file and compares its content to the settings, and adds missing entries with 
    /// their default value to the file and saves it.
    /// </summary>
    private void UpdateSettings()
    {
      // Load .config file
      Configuration configFile = ConfigurationManager.OpenExeConfiguration(typeof(Settings).Assembly.Location);
   
      // Get the wanted section
      ConfigurationSectionGroup sectionGroup = configFile.SectionGroups["applicationSettings"];
      ClientSettingsSection clientSettings = (ClientSettingsSection)sectionGroup.Sections[0];
   
      // Make sure the section really is saved later on
      clientSettings.SectionInformation.ForceSave = true;
      // Iterate through all properties
      foreach (SettingsProperty property in Settings.Default.Properties)
      {
        // if any element in Settings equals the property's name we know that it exists in the file
        bool exists = clientSettings.Settings.Cast<SettingElement>().Any(element => element.Name == property.Name);
        // Create the SettingElement with the default value if the element happens to be not there.
        if (!exists)
        {
          var element = new SettingElement(property.Name, property.SerializeAs);
          var xElement = new XElement(XName.Get("value"));
          XmlDocument doc = new XmlDocument();
          XmlElement valueXml = doc.ReadNode(xElement.CreateReader()) as XmlElement;
          valueXml.InnerText = property.DefaultValue.ToString();
          element.Value.ValueXml = valueXml;
          clientSettings.Settings.Add(element);
        }
      }
      // Save config
      configFile.Save();
    }
