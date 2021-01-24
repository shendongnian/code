    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    private void btGetSettings_Click(object sender, EventArgs e)
    {
        foreach(Control control in this.Controls)
        {
            // Check if is CheckBox
            if (control is CheckBox)
            {
                // Read the setting in App.config
                string value = config.AppSettings.Settings[control.Name].Value;
                ((CheckBox)control).Checked = Convert.ToBoolean(value);
            }
        }
        // Save and refresh settings
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
    private void btSaveSettings_Click(object sender, EventArgs e)
    {
        foreach (Control control in this.Controls)
        {
            if (control is CheckBox)
            {
                // Modify the setting in App.config
                config.AppSettings.Settings[control.Name].Value = ((CheckBox)control).Checked.ToString();
            }
        }
        // Save and refresh settings
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
