    static readonly Regex VersionRegex = new Regex(@"^v\d+(\.\d+)?$", 
                                                   RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public static string SkipToApplicationRoot(string path)
    {
      var di = new DirectoryInfo(path);
      while (di.Parent != null)
      {
        // If the current directory is a version string, return the path to the parent directory
        if (VersionRegex.IsMatch(di.Name)) return di.Parent.FullName;
        di = di.Parent;
      }
      // No version string in the path
      return null;
    }
