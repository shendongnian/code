    foreach (SettingsProperty  currentProperty in Properties.Settings.Default.Properties)
    {
        Properties.Settings.Default[currentProperty.Name] = result.ToString();
        Properties.Settings.Default.Save();
    }
