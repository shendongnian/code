            string filePath = System.IO.Path.GetFullPath("settings.app.config");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            try
            {
                // Open App.Config of executable
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                // Add an Application Setting if not exist
               
                    config.AppSettings.Settings.Add("key1", "value1");
                    config.AppSettings.Settings.Add("key2", "value2");
                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException ex)
            {
                if (ex.BareMessage == "Root element is missing.")
                {
                    File.Delete(filePath);
                    return;
                }
                MessageBox.Show(ex.Message);
            }
