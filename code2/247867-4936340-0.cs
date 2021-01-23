    stirng path = ConfigurationManager.AppSettings["Log.Directory"]
    if (!String.IsNullOrEmplty(path))
    {
        string file = Path.Combine(path, filename);
        // and so on...
    }
