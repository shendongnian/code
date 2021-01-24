    var configValues = ConfigurationManager.AppSettings["setConfigValues"]
        .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Distinct()
        .ToDictionary(
            item => item, item => (object)null, 
            StringComparer.InvariantCultureIgnoreCase);
    if (configValues.ContainsKey("loggingMode"))
    {
        // do stuff
    }
