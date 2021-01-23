    Version version;
    if (Version.TryParse("5.0.0.0", out version))
    {
        // your logic here
        return new Version(
             version.Major,
             version.Minor,
             version.Build,
             version.Revision + 1).ToString();
        // will return 5.0.0.1
    }
    else
    {
        // error handling here
    }
