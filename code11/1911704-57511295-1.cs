    var configValues = ConfigurationManager.AppSettings["setConfigValues"]
        .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Distinct()
        .ToDictionary(
            item => item,
            item => webConfigApp.AppSettings.Settings[item].Value, 
            StringComparer.InvariantCultureIgnoreCase);
    if (configValues.ContainsKey("loggingMode"))
    {
        // do stuff
    }
    if (configValues.TryGetValue("loggingMode", out string value) && value == "on")
    {
        // do stuff
    }
