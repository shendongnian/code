    var section = configuration.GetSection(sectionKey.ToString());
    var appSettings = section as AppSettingsSection;
    if (appSettings == null) continue;
    foreach (var key in appSettings.Settings.AllKeys)
    {
        System.Type type = key.GetType();
        var webService = new SecureWebService<type>().Service;
    }
