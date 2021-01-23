    public static Version IncrementMajor(this Version ver)
    {
      return new Version(ver.Major + 1, 0);
    }
    public static Version IncrementMinor(this Version ver)
    {
      return new Version(ver.Major, ver.Minor + 1);
    }
