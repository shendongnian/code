    Version version;
    if (Version.TryParse("5.0.0.0", out version))
    {
        // your logic here
        return new Version(
             version.Major,
             version.Minor,
             version.Build + 1,
             version.Revision).ToString();
        // will return 5.0.1.0
    }
    else
    {
        // error handling here
    }
