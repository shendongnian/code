    stirng path = ConfigurationManager.AppSettings["Languages"]
    if (!String.IsNullOrEmplty(path))
    {
        string file = Path.Combine(path, filename);
        // and so on...
    }
